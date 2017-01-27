address $000c0000

prochook $0027abc8 -j
event testSpawn $0071575c $7FFB
event unlock $0071575c $ffff
event teleLast $0071575c $bfff

string pName "GtlcBOT"

define pad_address $007157dc
define cAppCamera $00711268
define camCZSeal $dc
define xhair_X $03fc
define xhair_Y $0400
define xhair_Z $0404

fnc unlock(void)
{
	setreg v0, :disableDuplicates
	sw zero, $0000(v0)
}

fnc teleLast(void)
{
	setreg v0, :testSubjectPointer
	lw a0, $0000(v0)
	if (a0 <> 0)
	{
		setreg a1, :cAppCamera
		lw a1, $0000(a1)
		lw a1, :camCZSeal(a1)
		
		lw t0, :xhair_X(a1)
		lw t1, :xhair_Y(a1)
		lw t2, :xhair_Z(a1)
	
		sw t0, $001c(a0)
		sw t1, $0020(a0)
		sw t2, $0024(a0)
		
	}
}

fnc testSpawn(void) \s0,s1,s2,s3,s4
{
	setreg v0, :disableDuplicates
	lw v1, $0000(v0)
	if (v1 <> 0)
		return -3
	addiu v1, zero, 1
	sw v1, $0000(v0)
	
	setreg v0, :testSubjectPointer
	lw v1, $0000(v0)
	if (v1 <> 0)
		sw v1, $0000(v0)
	
	
	setreg s4, :tempSpace
	setreg s0, :testSubjectID
	
	call FindPlayerModelID(s0)
	s1 = v0
	if (s1 == 0)
		return -1
	
	
	setreg a0, :tempSpace2
	setreg a1, :pName
	jal $00521220
	sw zero, $0000(a0)
	
	
	jal $00181640
	a0 = $08f0
	
	if (v0 <> 0)
	{
		jal $003ea9a0
		a0 = v0
	}
	s2 = v0
	
	a0 = s1
	setreg a1, :tempSpace2
	jal $00419c10
	a2 = s2
	s3 = v0
	if (s3 == 0)
		return -2
	
	setreg v0, :testSubjectPointer
	sw s3, $0000(v0)
	
	/*
	setreg a0, :tempSpace2
	addiu a0, a0, 4
	setreg a1, :pName
	jal $00521220
	sw zero, $0000(a0)
	
	*/
	//setreg v0, $80010000
	//sw v0, $00d8(s3)
}
disableDuplicates:
nop

memalign quad

testSubjectPointer:
nop
nop
nop
nop

memalign quad
testSubjectID:
hexcode $efc454c7
hexcode $00000b01
hexcode $36e3558f
hexcode $00c95d0d


memalign quad
tempSpace:
nop
nop
nop
nop

memalign quad
tempSpace2:
nop
nop
nop
nop


extern $003b6a90 FindPlayerModelID(EE a0)
