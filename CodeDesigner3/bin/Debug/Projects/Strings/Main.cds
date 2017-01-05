address $00090000


prochook $002e4e74 -j

event padInput_SQ $007157dc $7fff
event padInput_O $007157dc $DFFF

memalign quad
savedata:
nop
nop
nop
nop

fnc test(void)
{
	call _tinyFont_ByteToBIN(100)
}


fnc padInput_SQ(void) \s0
{
	/*
	setreg s0, :savedata
	ld v0, $0000(s0)
	if (v0 == 0)
	{
		call gs_GetDisplay()
		sd v0, $0000(s0)
		sd v1, $0008(s0)
	}
	call gs_ClearBuffer(255, 255, 255)
	*/
	string helloworld "Hello\nWorld!"
	setreg s0, :helloworld
	
	call gif_DrawStringTF(s0, 0, 0, 255, 0, 0)
	
}


fnc padInput_O(void) \s0
{
	setreg s0, :savedata
	ld a0, $0000(s0)
	ld a1, $0008(s0)
	if (a0 <> 0)
	{
		call gs_RestoreDisplay(a0, a1)
	}
}