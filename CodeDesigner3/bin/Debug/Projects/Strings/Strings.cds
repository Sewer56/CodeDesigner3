/*
	Strings Library
	Created by: Gtlcpimp
*/

//============================================================
// Upper Case -> Converts to Upper Case
/*
Input:
	a0 = &String

C Syntax Equivalent:
	void toUpperCase(char *src)
*/

fnc UCase(EE a0) \s0,s1
{
	// Take our pointer to the string
	s0 = a0
	
	// Find out the length of the string
	call strLen(s0)
	s1 = v0
	
	// Loop through the entire string by its length
	for (a0 = 0; a0 < s1; a0++)
	{
		// Load the character at our current position
		lbu v0, $0000(s0)
		
		// Check to see if it's a lower 'a' or greater value
		if (v0 >= $61)
		{
			// Check to see if it's a lower 'z' or less (a-z)
			if (v0 < $7b)
			{
				// Decrease it's value to that of the Upper
				// Case letters, then store back in place
				v0 -= $20
				sb v0, $0000(s0)
			}
		}
		
		// Increment our position in the string
		s0++
	}
	// Return nothing, function is void
}

//============================================================
// Lower Case -> Converts to Lower Case
/*
Input:
	a0 = &String

C Syntax Equivalent:
	void toLowerCase(char *src)
*/
fnc LCase(EE a0) \s0,s1
{
	// Take our pointer to the string
	s0 = a0
	
	// Find out the length of the string
	call strLen(s0)
	s1 = v0
	
	// Loop through the entire string by its length
	for (a0 = 0; a0 < s1; a0++)
	{
		// Load the character at our current position
		lbu v0, $0000(s0)
		
		// Check to see if it's a capital 'A' or greater value
		if (v0 >= $41)
		{
			// Check to see if it's a capital 'Z' or less (A-Z)
			if (v0 < $5b)
			{
				// Increment it's value to that of the Lower
				// Case letters, then store back in place
				v0 += $20
				sb v0, $0000(s0)
			}
		}
		
		// Increment our position in the string
		s0++
	}
	// Return nothing, function is void
}

//============================================================
// String Length -> Gets the length of the string
/*
Input:
	a0 = String
Output:
	v0 = String Length

C Syntax Equivalent:
	int strLen(char *src)
*/
fnc strLen(EE a0)
{
	// Start our counter at 0
    v0 = 0
    
    // Check the first character to make sure it's not empty
    lbu v1, $0000(a0)
    while (v1)
    {
    	// Load the character at our current position
        lbu v1, $0000(a0)
        
        // Check if it's the end of the string
        if (v1 == 0)
        	break;
        
        // Increment our position in the string
        a0++
        
        // Increment our counter, we aren't at the end yet
        v0++
    }
    // Return register v0 is already loaded as the counter
    // and will be returned to the parent function
}

//============================================================
// String Clear -> Erases the entire string (places NULL chars)
/*
Input:
	a0 = String

C Syntax Equivalent:
	void strClear(char *src)
*/
fnc strClear(EE a0)
{
	// Make sure we aren't already at the end of the string
	lbu v0, $0000(a0)
	while (v0)
	{
		// Store a NULL char (erasing the existing char)
		sb zero, $0000(a0)
		
		// Increment our position in the string
		a0++
		
		// Load the next char for checking if it's the end
		lbu v0, $0000(a0)
	}
	// Return nothing, function is void
}

//============================================================
// String Copy -> Copies a string to the specified destination
/*
Input:
	a0 = Source String
	a1 = Destination String
	a2 = Source Start Position (index)
Output:
	v0 = End of Source String (NULL + 1)
	v1 = Number of chars copied

C Syntax Equivalent:
	int strCopy(char *src, char *dst, int index)
*/
fnc strCopy(EE a0, EE a1, EE a2) \s0,s1
{
	// Set our position in the Source String
	daddu s0, a0, a2
	
	// Set our destination
	s1 = a1
	
	// Make sure we aren't at the end of the source string
	lbu v1, $0000(s0)
	while (v1)
	{
		// Store our character in the destination string
		sb v1, $0000(s1)
		
		// Increment to the next position in the Source
		s0++
		
		// Increment to the next position in the Destination
		s1++
		
		// Load the character next character to copy
		lbu v1, $0000(s1)
	}
	
	// End our destination string by placing a NULL character
	sb zero, $0000(s1)
	
	// Set our return register v1 to the copied byte count
	subu v1, s1, a1
	
	// Set our return register v0 to be end of source + 1
	addiu v0, s1, 1
}

//============================================================
// String Concatenate -> Appends a string to another
/*
Input:
	a0 = Destination String
	a1 = String to copy
Output:

C Syntax Equivalent:

*/
fnc strConcat(EE a0, EE a1) \s0,s1,s2
{
	
}


//============================================================
// String Compare -> Compares 2 Strings
/*
Input:
   a0 = String 1
   a1 = String 2
Output:
   v0 = -1 or 0 or 1
   	-1: String 1 goes before String 2 (alphabetically)
   	 0: Strings are identical
   	 1: String 1 goes after String 2 (alphabetically)
C Syntax Equivalent:
	int strCompare(char *str1, char *str2)
*/
fnc strCompare(EE a0, EE a1) \s0,s1,s2
{
	s0 = a0
	s1 = a1
	
	// Get length of String 1
	call strLen(s0)
	s2 = v0
	
	// Get length of String 2
	call strLen(s1)
	
	// Check if String 1 is shorter than String 2
	if (s2 < v0)
		return -1
	
	// Check if String 1 is longer than String 2
	if (s2 > v0)
		return 1
	
	for (a0 = 0; a0 < s2; a0++)
	{
		lbu v0, $0000(s0)
		lbu v1, $0000(s1)
		
		// Compare if str1[x] is less than str2[x]
		if (v0 < v1)
			return -1
		
		// Compare if str1[x] is greater than str2[x]
		if (v0 > v1)
			return 1	
	}
	
	// Both strings are 100% identical
	v0 = 0
}

//============================================================
// Hex -> Converts a value into a Hex String
/*
Input:
	a0 = Value
	a1 = Destination String
	a2 = Hex Digits Limit

*/
fnc Hex(EE a0, EE a1, EE a2) \s0,s1,s2
{
	s0 = a0
	addu s1, a1, a2
	s2 = a2
	
	sb zero, $0000(s1)
	s1--
	while (s2)
	{
		andi v0, s0, $F
		
		if (v0 < 10)
			v0 += $30
		else
			v0 += $41
		
		sb v0, $0000(s1)
		s0 >> 4
		s1--
		s2--
	}
}
























