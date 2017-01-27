address $003c66c8
j :main

address $000c0000

define pad_address $007157dc
define cAppCamera $00711268
define camCZSeal $dc
define xhair_X $03fc
define xhair_Y $0400
define xhair_Z $0404

fnc main(void)\s0,s1,s2,s3
{
	call Controller_KeyPress()
	switch (v0)
	{
		case $fffb // r3
		{
			call spawnRocket()
		}
	}
}

fnc spawnRocket(void) \s0,s1,s2,s3,s4,f0,f1,f2,f3
{
	addiu sp, sp, $fe80
	s0 = sp
	addiu sp, sp, $ff00
	s1 = sp
	
	
	setreg s2, :cAppCamera
	lw s2, $0000(s2)
	if (s2 == 0)
		return 0
	lw s2, $00dc(s2)
	if (s2 == 0)
		return 0
	
	v1 = s0
	for (v0 = 0; v0 < $0180; v0 += $10)
	{
		sq zero, $0000(v1)
		v1 += $10
	}
	sq zero, $0000(s1)
	sq zero, $0010(s1)
	sq zero, $0020(s1)
	sq zero, $0030(s1)
	
	
	jal $005738e0
	a0 = s0
	
	//------------------------------ Set AT-4
	setreg v0, $00cf82d4 // AT-4
	sw v0, $0000(s1)
	addiu v1, s1, $40
	sw v1, $0014(s1)
	setreg v0, $00cf8458 // AT-4 Ammo
	sw v0, $0000(v1)
	
	addiu a0, v1, $40
	sw a0, $0004(v1)
	addiu v0, a0, 4
	sw v0, $0008(v1)
	sw v0, $000c(v1)
	addiu v0, zero, $7fff
	sw v0, $0000(a0)
	
	addiu v0, s1, $0014
	sw v0, $0004(s1)
	v0 += 4
	sw v0, $0008(s1)
	sw v0, $000c(s1)
	
	
	addiu a2, s2, $0740
	lw a2, $0000(a2)
	lw a2, $0000(a2)
	
	setreg v1, $00CF8018
	sw v1, $0000(a2)
	
	lw v0, $0014(a2)
	setreg v1, $00CF819C
	sw v1, $0000(v0)
	
	s1 = a2
	
	addiu a0, s2, $06f0
	a1 = s0
	a2 = s1
	a3 = 0
	//jal $00496ed0
	t0 = 0
	
	
	lui v0, $41A0
	mtc1 v0, f3
	
	lwc1 f0, $001c(s2)//:xhair_X(s2)
	lwc1 f1, $0020(s2)//:xhair_Y(s2)
	lwc1 f2, $0024(s2)//:xhair_Z(s2)
	
	//add.s f0, f0, f3
	add.s f1, f1, f3
	//add.s f2, f2, f3
	swc1 f0, $0000(s0)
	swc1 f1, $0004(s0)
	swc1 f2, $0008(s0)
	
	lwc1 f0, :xhair_X(s2)
	lwc1 f1, :xhair_Y(s2)
	lwc1 f2, :xhair_Z(s2)
	//sub.s f0, f0, f3
	//sub.s f1, f1, f3
	//sub.s f2, f2, f3
	swc1 f0, $000c(s0)
	swc1 f1, $0010(s0)
	swc1 f2, $0014(s0)
	
	
	lui v0, $C2C4
	sw v0, $001c(s0)
	
	lui v0, $3f80
	sw v0, $003c(s0)
	
	sw s1, $0044(s0)
	
	
	setreg v0, $3D08AC16
	sw v0, $0060(s0)
	
	
	v0 = 1
	sw v0, $0064(s0)
	v0 = $71
	sw v0, $0068(s0)
	sw zero, $006c(s0)
	
	
	lui v0, $42C8
	sw v0, $0070(s0)
	setreg v0, $BE804490
	sw v0, $0074(s0)
	lui v0, $BF80
	sw v0, $0080(s0)
	
	
	setreg a0, $0079d410
	a1 = s0
	jal $0057e5c0
	a2 = 0
	
	s3 = v0
	
	/*
	addiu a0, s2, $06f0
	jal $00496130
	a1 = s3
	
	//jal $00585bf0
	//lw a0, $0068(s3)
	//if (v0 == 0)
	//	return 0
	
	a0 = s2
	a1 = s2
	jal $003ba620
	a2 = s0
	
	addiu v0, s2, $06f0
	v1 = 1
	sb v1, $0002(v0)
	
	
	
	a0 = s0
	jal $00573890
	a1 = -1
	*/
	addiu sp, sp, $0280
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
