

fnc UCase(EE a0) \s0,s1
{
	// Take our pointer to the string
	s0 = a0
	
	// Find out the length of the string
	call strLen(s0)
	s1 = v0
	
	for (a0 = 0; a0 < s1; a0++)
	{
		lbu v0, $0000(s0)
		if (v0 >= $61)
		{
			if (v0 < $7b)
			{
				v0 -= $20
				sb v0, $0000(s0)
			}
		}
		s0++
	}
}


fnc LCase(EE a0) \s0,s1
{
	// Take our pointer to the string
	s0 = a0
	
	// Find out the length of the string
	call strLen(s0)
	s1 = v0
	
	for (a0 = 0; a0 < s1; a0++)
	{
		lbu v0, $0000(s0)
		if (v0 >= $41)
		{
			if (v0 < $5b)
			{
				v0 += $20
				sb v0, $0000(s0)
			}
		}
		s0++
	}
}

fnc strLen(EE a0)
{
    v0 = 0
    lbu v1, $0000(a0)
    while (v1)
    {
        lbu v1, $0000(a0)
        if (v1 == 0)
        	break;
        a0++
        v0++
    }
}
