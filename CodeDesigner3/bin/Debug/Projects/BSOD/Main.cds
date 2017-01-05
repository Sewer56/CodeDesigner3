/*
	Exception Display (Blue Screen of Death)
	Created by: Gtlcpimp
*/







//============================================================
// Exception Display
fnc DisplayException(void)
{
	
}

//============================================================
// Enter User Kernel Mode
fnc ee_kmode_enter(void)
{
	mfc0 v0, status
	v1 = -25
	and v0, v0, v1
	mtc0 v0, status
	sync.p
}

//============================================================
// Exit User Kernel Mode
fnc ee_kmode_exit(void)
{
	mfc0 v0, status
	ori v0, v0, $0010
	mtc0 v0, status
	sync.p
}

