/*
	CodeDesigner v3 ~ Created by: Gtlcpimp
*/
address $00637488
jal :nodeTests

address $000c0000

define pad_address $007157dc
define cAppCamera $00711268
define camCZSeal $dc
define xhair_X $03fc
define xhair_Y $0400
define xhair_Z $0404

/*
Input:
	a0 = X,Y,Z Pointer 1
	a1 = X,Y,Z Pointer 2
Output:
	v0 = Distance (divided by 10 for meters in socom)
*/
fnc getDistance(EE a0, EE a1) \f0,f1,f2,f3,f4,f5,f6,f7,s0,s1,s2
{
	lwc1 f0, $0000(a0) // Load x1
	lwc1 f1, $0004(a0) // Load y1
	lwc1 f2, $0008(a0) // Load z1
	
	lwc1 f3, $0000(a1) // Load x2
	lwc1 f4, $0004(a1) // Load y2
	lwc1 f5, $0008(a1) // Load z2
	
	// (X2 - X1)^2
	sub.s f6, f3, f0
	mul.s f6, f6, f6
	
	// (Z2 - Z1)^2
	sub.s f7, f5, f2
	mul.s f7, f7, f7
	
	// (a^2)+(b^2) (x and z)
	add.s f6, f6, f7
	
	// (Y2 - Y1)^2
	sub.s f7, f4, f1
	mul.s f7, f7, f7
	
	// (a^2)+(b^2) (xz;;y)
	add.s f6, f6, f7
	
	sqrt.s f7, f6
	
	// Divide by 10 for socom's meters
	//lui v0, $4120
	//mtc1 v0, f6
	//div.s f7, f7, f6
	
	// Convert to word and return it
	cvt.w.s f6, f7
	mfc1 v0, f6
}

fnc getMainWorld(void)
{
	setreg a0, $00743c84
	lw a0, $0000(a0)
	lw a0, $0000(a0)
	lw a0, $0008(a0)
	lw a1, $001c(a0)
	lw a0, $0018(a0)
	
	while (a0 < a1)
	{
		lw t0, $0000(a0)
		lw t0, $0058(t0)
		if (t0 <> 0)
		{
			lw t1, $0000(t0)
			setreg t2, $006e6980
			if (t1 == t2)
				return t0
		}
		a0 += 4
	}
	v0 = 0
}

fnc nodeTests(void) \v0,a0,a1,a2,a3,s0,s1,s2,s3,s4,s5,s6,s7
{
	s3 = a0
	
	setreg s1, :cAppCamera
	lw a0, $0000(s1)
	if (a0 <> 0)
	{
		lw s0, :camCZSeal(a0)
		if (s0 <> 0)
		{
			lw s2, $0030(s0)
			lw s2, $0078(s2)
			
			call getMainWorld()
			s1 = v0
			//if (s1 <= 0)
			//	return 0
			
			// s0 = my pointer
			// s1 = main world pointer
			// s2 = local nearby world pointer
			
			addiu a0, s0, $001c
			addiu a1, s0, :xhair_X
			call getDistance(a0, a1)
			s4 = v0
			
			call findNearestNode(s2, s0)
			s5 = v0
			
			if (s1 <> 0)
			{
				call findNearestNode(s1, s0)
				s6 = v0
				
				addiu a0, s0, :xhair_X
				addiu a1, s5, $0040
				call getDistance(a0, a1)
				s7 = v0
				
				addiu a0, s0, :xhair_X
				addiu a1, s6, $0040
				call getDistance(a0, a1)
				
				if (s7 <= v0)
				{
					v1 = s5
				}
				else
				{
					s5 = s6
					lui v1, $2000
					or s5, s5, v1
				}
				
			}
			
			addiu a0, s0, :xhair_X
			addiu a1, s5, $0040
			call getDistance(a0, a1)
			
			// Debug print out (replaces ammo text)
			daddu a0, s3, zero
			addiu a1, zero, $0024
			setreg a2, :formatStr
			daddu a3, s5, zero
			jal $001d4520 // printf
			daddu t0, v0, zero
			
			setreg v0, $006d3bc8
			sw zero, $0000(v0)
			
			call Controller_KeyPress()
			switch (v0)
			{
				case $FDFF // R2
				{
					setreg v0, :storeage
					sw s5, $0000(v0)
				}
				case $FFFB // R3
				{
					setreg v0, :storeage
					lw a0, $0000(v0)
					
					if (a0 <> 0)
					{
						lw t0, :xhair_X(s0)
						lw t1, :xhair_Y(s0)
						lw t2, :xhair_Z(s0)
						
						sw t0, $0040(a0)
						sw t1, $0044(a0)
						sw t2, $0048(a0)
						
						lw a0, $0030(s0)
						lq t0, $0010(a0)
						lq t1, $0020(a0)
						lq t2, $0030(a0)
						sq t0, $0010(s5)
						sq t1, $0020(s5)
						sq t2, $0030(s5)
					}
				}
			}
		}
	}
}

/*
Input:
	a0 = (zdb::CWorld) Pointer
	a1 = Player Pointer (For X-Hairs)
Output:
	v0 = Nearest NODE Pointer
*/
fnc findNearestNode(EE a0, EE a1) \s0,s1,s2,s3,s4,s5,f0,f1,f2,f3,f4,f5
{
	s4 = a0
	addiu s0, a0, $0050 //$0110
	lw s1, $0004(s0)
	lw s0, $0000(s0)
	s2 = a1
	
	setreg s3, :lastDistance
	lui v0, $7fff
	ori v0, v0, $ffff
	sw v0, $0000(s3)
	
	s5 = 0
	
	part2:
	while (s0 < s1)
	{
		lw a0, $0000(s0)
		lw v0, $0000(a0)
		setreg v1, $006e68e0
		if (v0 == v1)
		{
			lw v1, $0030(s2)
			if (a0 <> v1)
			{
				addiu a0, a0, $0040
				addiu a1, s2, :xhair_X
				call getDistance(a0, a1)
				
				lw a0, $0000(s3)
				if (v0 < a0)
				{
					sw v0, $0000(s3)
					lw v0, $0000(s0)
					sw v0, $0004(s3)
				}
			}
		}
		
		s0 += 4
	}
	if (s5 == 0)
	{
		s5 = 1
		addiu s0, s4, $0110
		lw s1, $0004(s0)
		lw s0, $0000(s0)
		goto :part2
	}
	
	lw v0, $0004(s3)
}

fnc Controller_KeyPress(void) \s0,s1
{
	beq zero, zero, :Controller_KeyPress_SaveData_Branch
	nop
	Controller_KeyPress_SaveData:
	nop
	Controller_KeyPress_SaveData_Branch:
	
	setreg s0, :pad_address
	setreg s1, :Controller_KeyPress_SaveData
	
	lhu a0, $0000(s0)
	xori a0, a0, $ffff
	
	lhu a1, $0000(s1)
	nor a2, a1, a1
	and v0, a0, a2
	sw a0, $0000(s1)
	
	addiu v1, zero, -1
	xor v0, v0, v1
	
	// v0 = new button press
}
lastDistance:
nop
nop

formatStr:
print "%08X  %dm"

storeage:
nop
