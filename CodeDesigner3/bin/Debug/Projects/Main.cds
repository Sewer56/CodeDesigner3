address $00100000

/*
	Test
*/

string hello "HELLO WORLD!"

fnc main(void)
{
	setreg s0, :hello
	
	call LCase(s0)
	
	call UCase(s0)
	
	return 1
}
