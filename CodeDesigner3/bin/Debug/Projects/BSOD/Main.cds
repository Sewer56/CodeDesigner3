/*
	Exception Display (Blue Screen of Death)
	Created by: Gtlcpimp
*/
hexcode :debugDisplay

address $001d8c60
j :debugCopy
nop

address $00090000

debugRunPrint:
addiu sp, sp, $ffe0
j $001d8c68
sd s0, $0000(sp)

fnc debugCopy(void) \at,v0,v1,a0,a1,a2,a3,t0,t1,t2,t3,t4,t5,t6,t7,t8,t9,s0,s1,s2,s3,s4,s5,s6,s7,k0,k1,gp,fp
{
	setreg s1, $00088000
	
	jal :debugRunPrint
	lw s0, $0000(a0)
	
	
/*
Input:
	a0 = &String
	a1 = Coordinate X
	a2 = Coordinate Y
	a3 = Color R
	t0 = Color G
	t1 = Color B
*/
	if (s0 <> 0)
	{
		v1 = 0
		lb v0, $0000(s0)
		while (v0)
		{
			sb v0, $0000(s1)
			s1++
			s0++
			lb v0, $0000(s0)
			v1++
			if (v1 > 60)
				break;
		}
	}
	sb zero, $0000(s1)
}

fnc debugDisplay(void) \fp
{
	lui fp, $0009
	sq sp, $fff0(fp)
	
	setreg sp, $000ffff0
	
	setreg a0, $00088000
	lb v0, $0000(a0)
	if (v0 <> 0)
	{
		call gif_DrawStringTF(a0, 5, 5, 255, 255, 255)
	}
	
	lui fp, $0009
	lq sp, $fff0(fp)
}


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

