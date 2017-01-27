//address $0024d4ac
//jal :test

// 0147B6F0

//address $000c0000

//test:

//lui a0, $0188
//j $003740d0
//ori a0, a0, $2ae0


address $003c66c8
j :main

address $000f0000

define pad_address $007157dc
define cAppCamera $00711268
define camCZSeal $dc
define xhair_X $03fc
define xhair_Y $0400
define xhair_Z $0404

fnc main(void)
{
	call Controller_KeyPress()
	switch (v0)
	{
		case $fffb
		{
			call spawnTest()
		}
		case $fffd
		{
			call allocTest()
		}
	}
}

fnc allocTest(void) \s0,s1,s2,s3
{
	
}

fnc spawnTest(void) \s0,s1,s2,s3
{
	
	setreg a0, $01883ec0
	a1 = 0
	jal $003740d0
	a2 = 0
	
	s0 = v0
	if (s0 <= 0)
		return 0;
	
	//setreg s0, $0116a130
	setreg s1, :cAppCamera
	lw s1, $0000(s1)
	lw s1, $00dc(s1)
	
	lw t0, :xhair_X(s1)
	lw t1, :xhair_Y(s1)
	lw t2, :xhair_Z(s1)
	
	sw t0, $0040(s0)
	sw t1, $0044(s0)
	sw t2, $0048(s0)
	
	setreg a0, $00743CD0
	a1 = s0
	a2 = 0
	jal $0037fad0
	a3 = 1
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
