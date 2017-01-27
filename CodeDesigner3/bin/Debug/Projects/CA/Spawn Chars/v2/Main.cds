/*
	CodeDesigner v3 ~ Created by: Gtlcpimp
*/
address $001d15a0
j :AI_Control_Patch_2
nop

address $000c0000

prochook $0027abc8 -j
hook botNameFix $0028ca9c -jal

define pad_address $007157dc
define cAppCamera $00711268
define camCZSeal $dc
define xhair_X $03fc
define xhair_Y $0400
define xhair_Z $0404

thread main
thread autoRespawn /delay 1500

fnc main(void)
{
	call Controller_KeyPress()
	switch (v0)
	{
		case $FFFD // L3
		{
			call spawnTest()
		}
		case $FFFB // R3
		{
			call spawnVehTest()
		}
	}
	
	call iconTest()
}

fnc iconTest(void) \s0,s1,s2
{
	setreg s0, :cAppCamera
	lw s0, $0000(s0)
	lw s0, $00dc(s0)
	
	a0 = s0
	a1 = 1
	jal $003bc630
	a2 = 1
	
}

fnc spawnVehTest(void) \s0,s1,s2,s3,s4
{
	setreg v0, $0073f900
	lw s4, $0000(v0)
	//sw zero, $0000(v0)
	
	setreg s0, :cAppCamera
	lw s0, $0000(s0)
	lw s0, $00dc(s0)
	
	lw t0, $03fc(s0)
	lw t1, $0400(s0)
	lw t2, $0404(s0)
	
	setreg v0, :CUSTOM_VEHICLE_DATA
	sw t0, $006c(v0)
	sw t1, $0070(v0)
	sw t2, $0074(v0)
	setreg v0, :VEH_ARG_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	/*
	setreg a0, $00709890
	setreg a1, :CUSTOM_VEHICLE_DATA
	jal $0028dc70
	nop
	if (v0 == 0)
		return -1
	*/
	
	setreg a0, :VEH_ARG_a2
	setreg a1, :CUSTOM_VEHICLE_DATA
	jal $00521220
	sw zero, $0000(a0)
	
	
	lw t0, $03fc(s0)
	lw t1, $0400(s0)
	lw t2, $0404(s0)
	
	setreg v0, :CUSTOM_VEHICLE_DATA
	sw t0, $006c(v0)
	sw t1, $0070(v0)
	sw t2, $0074(v0)
	setreg v0, :VEH_ARG_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	setreg a0, :CUSTOM_VEHICLE_DATA
	jal $002266c0
	a1 = 0
	
	
	lw t0, $03fc(s0)
	lw t1, $0400(s0)
	lw t2, $0404(s0)
	
	setreg v0, :CUSTOM_VEHICLE_DATA
	sw t0, $006c(v0)
	sw t1, $0070(v0)
	sw t2, $0074(v0)
	setreg v0, :VEH_ARG_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	setreg a0, $00706650
	setreg a1, :VEH_ARG_a3
	setreg a2, :VEH_ARG_a2
	a2 += 4
	jal $00222330
	a3 = 0
	
	
	lw t0, $03fc(s0)
	lw t1, $0400(s0)
	lw t2, $0404(s0)
	
	setreg v0, :CUSTOM_VEHICLE_DATA
	sw t0, $006c(v0)
	sw t1, $0070(v0)
	sw t2, $0074(v0)
	setreg v0, :VEH_ARG_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	setreg a0, :CUSTOM_VEHICLE_DATA
	jal $00226630
	nop
	
	
	lw t0, $03fc(s0)
	lw t1, $0400(s0)
	lw t2, $0404(s0)
	
	setreg v0, :CUSTOM_VEHICLE_DATA
	sw t0, $006c(v0)
	sw t1, $0070(v0)
	sw t2, $0074(v0)
	setreg v0, :VEH_ARG_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	andi a0, v0, $00ff
	setreg a1, :VEH_ARG_00b0
	jal $0020ed60
	a2 = 1
	
	lw t0, $03fc(s0)
	lw t1, $0400(s0)
	lw t2, $0404(s0)
	
	setreg v0, :CUSTOM_VEHICLE_DATA
	sw t0, $006c(v0)
	sw t1, $0070(v0)
	sw t2, $0074(v0)
	setreg v0, :VEH_ARG_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	setreg v1, :VEH_ARG_a2
	lbu v0, $0004(v1)
	setreg a0, $00706650
	jal $0021e510
	andi a1, v0, $003f
	
	
	setreg a0, $00709890
	setreg a1, :CUSTOM_VEHICLE_DATA
	setreg a2, :VEH_ARG_a2
	a2 += 4
	setreg a3, :VEH_ARG_a3
	sw t0, $0000(a3)
	sw t1, $0004(a3)
	sw t2, $0008(a3)
	sw t0, $006c(a1)
	sw t1, $0070(a1)
	sw t2, $0074(a1)
	setreg t0, :VEH_ARG_t0
	jal $0028cf90
	nop
	
	setreg v0, $0073f900
	sw s4, $0000(v0)
}


hook AI_Control_Patch $003e2e1c -jal

fnc AI_Control_Patch(void) \s0,s1,s2
{
	s0 = a0
	
	lw s1, $014c(s0)
	if (s1 <> 0)
	{
		jal $00441440
		nop
	}
}

AI_Control_Patch_2:
beq a1, zero, :AI_Control_Patch_2_Exit
daddu t0, a0, zero
j $001d15a8
sltiu v0, a2, $0020
AI_Control_Patch_2_Exit:
jr ra
nop

fnc autoRespawn(void) \s0,s1
{
	setreg s0, $00709680
	lw a0, $0000(s0)
	lw a1, $0004(s0)
	
	for (a0 = a0; a0 < a1; a0 += 4)
	{
		lw s1, $0000(a0)
		lw s1, $0030(s1)
		lw s1, $0008(s1)
		
		setreg v0, :cAppCamera
		lw v0, $0000(v0)
		lw v0, $00dc(v0)
		lw v0, $0030(v0)
		lw v0, $0008(v0)
		if (s1 <> v0)
		{
			lw v0, $0128(s1)
			if (v0 <= 0)
			{
				addiu v0, zero, 1
				sb v0, $00A7(s1)
			}
		}
	}
}

//spawnArgs_a0:
define spawnArgs_a0, $00709890


memalign quad
spawnArgs_a2:
hexcode $ffffffff
hexcode $02880540//$48E21929
hexcode $006EBED8
nop
nop
nop
hexcode $00000001
nop

memalign quad
spawnArgs_a3:
nop // x
nop // y
nop // z
hexcode $3f800000
/*
hexcode $00000001
nop
nop
hexcode $438821e3 //64495242
hexcode $1efa0728 //4A1247DD
nop
nop
nop
*/

memalign quad
spawnArgs_t0:
hexcode $00000000
hexcode $B3BBBE2F
hexcode $00000000
hexcode $BF800000
nop
nop
nop
nop

fnc workingSpawn(void) \s0,s1,s2,s3,s4
{
	/*
	addiu sp, sp, $fff0
	s0 = sp
	
	setreg v0, $efc454c7
	sw v0, $0000(s0)
	
	// Player Model Finder
	jal $003b6a90
	a0 = s0
	*/
	jal $003501f0
	a0 = 0
	
}

fnc spawnTest(void) \s0,s1,s2,s3,s4
{
	setreg v0, $0073f900
	lw s4, $0000(v0)
	sw zero, $0000(v0)
	
	code 2045d718 00000000
	code 2045d5f0 00000000
	code 2045d780 00000000
	code 2045d808 00000000
	code 2045d918 00000000
	code 2045d970 00000000
	code 2045d9c8 00000000
	code 2045da20 00000000
	code 2045da78 00000000
	code 2045dad0 00000000
	
	
	setreg s0, :cAppCamera
	lw s0, $0000(s0)
	lw s0, $00dc(s0)
	
	setreg a0, $00706650
	setreg a2, :spawnArgs_a2
	jal $00221bb0
	nop
	
	
	lw t0, :xhair_X(s0)
	lw t1, :xhair_Y(s0)
	lw t2, :xhair_Z(s0)
	setreg v0, :spawnArgs_a3
	sw t0, $0000(v0)
	sw t1, $0004(v0)
	sw t2, $0008(v0)
	
	// Fix Skin for Map
	setreg s3, $00773348
	lw s3, $0000(s3)
	lw a0, $0008(s3)
	lw a1, $000c(s3)
	
	setreg v1, :lastSkin
	lw v0, $0000(v1)
	v0 += 1
	sw v0, $0000(v1)
	v0 << 2
	a0 += v0
	
	if (a0 > a1)
	{
		sw zero, $0000(v1)
		lw a0, $0008(s3)
		a0 += 4
	}
	
	lw a2, $0000(a0)
	lw a3, $0004(a2)
	if (a3 == 0)
	{
		a0 -= 4
		sw zero, $0000(v1)
	}
	
	lw a2, $0000(a0)
	lw v0, $0000(a2)
	lw v1, $0004(a2)
	
	/*
	for (a0 = a0; a0 < a1; a0 += 4)
	{
		lw a2, $0000(a0)
		lw a3, $0004(a2)
		if (a3 == 0)
		{
			a0 -= 4
			lw a2, $0000(a0)
			lw v0, $0000(a2)
			lw v1, $0004(a2)
			break;
		}
	}
	*/
	
	setreg a0, :CUSTOM_AI_DATA
	sw v0, $0040(a0)
	sw v1, $004c(a0)
	
	
	
	//define CUSTOM_AI_DATA $00709c80
	setreg a0, :spawnArgs_a0
	setreg a1, :CUSTOM_AI_DATA
	//lw a1, $0000(a1)
	//lw a1, $0000(a1)
	setreg a2, :spawnArgs_a2
	setreg a3, :spawnArgs_a3
	setreg t0, :spawnArgs_t0
	jal $0028c940 // Spawn Player/AI Function
	nop
	s1 = v0
	
	if (s1 <> 0)
	{
		/*
		setreg a0, $00711910
		a1 = s1
		jal $002cc470
		a2 = 0
		
		setreg a0, $0074fbe0
		jal $003b09d0
		a1 = s1
		*/
		
		setreg v0, :lastTeamID
		lw v1, $0000(v0)
		sw v1, $00d8(s1)
		
		if (v1 == $80000100)
		{
			setreg v1, $40000001
		}
		else
		{
			setreg v1, $80000100
		}
		sw v1, $0000(v0)
		
		/*
		addiu v0, zero, 1
		sw v0, $000c(s1)
		
		setreg a0, $00711910
		a1 = s1
		jal $002cc470
		a2 = 0
		
		setreg a0, $0074fbe0
		jal $003b09d0
		a1 = s1
		*/
	}
	setreg v0, $0073f900
	sw s4, $0000(v0)
	
}
lastSkin:
nop
lastTeamID:
hexcode $80000100


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

fnc botNameFix(void) \s0,s1,s2
{
	s0 = a0
	string newBotName "GtlcBot %d"
	setreg s1, :newBotName
	
	addiu sp, sp, $ff80
	sq zero, $0000(sp)
	sq zero, $0010(sp)
	sq zero, $0020(sp)
	sq zero, $0030(sp)
	s2 = sp
	
	a0 = s2
	a1 = $24
	setreg v0, :botNameFixCount
	lw a3, $0000(v0)
	a3++
	sw a3, $0000(v0)
	t0 = 0
	jal $001d4520
	a2 = s1
	
	a0 = s0
	jal $0027ac00
	a1 = s2
	
	addiu sp, sp, $0080
}
botNameFixCount:
nop
