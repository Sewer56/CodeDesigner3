address $00100000

/*
	Test
*/

string hello "HELLO WORLD!"

string hello2 "hello world!"

string outp "        "

fnc main(void)
{
	call Hex(1337, :outp, 8)
	
	return 1
}
