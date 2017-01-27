address $001840f8
hexcode $241300a0

address $00183b24
jal :decryptTest

address $00080000

string file_00 "S3CORE"
string file_01 "RTBASEv1.4"
string file_02 "RTCERTv1.4"
string file_03 "RTCOMMv1.4"
string file_04 "RTCRYPTv1.4"
string file_05 "RTINETCv1.4"
string file_06 "RTMEDIAv1.4"
string file_07 "RTMEDIASv1.4"
string file_08 "RTMCLv1.4"
string file_09 "RTMGCLv1.4"
string file_0a "RTMSGCLv1.4"
string file_0b "RTOBJECTv1.4"
string file_0c "RTP2Pv1.4"
string file_0d "RTSSLv1.4"
string file_0e "INETCV6v1.4"

define binAddr $00088000

fnc writeOutput(EE a0, EE a1, EE a2, EE a3)
{
	sw a1, $0000(a0) // &Data
	sw a2, $0004(a0) // File Size
	sw a3, $0008(a0) // Full Size
	
	addiu v0, a0, $000c
	a1 += a3
	addiu v1, a1, $0020
}

fnc decryptTest(void) \s0,s1,s2
{
	setreg s0, :dumpWrite
	setreg s1, :binAddr
	
	call memAlloc($40, $00800000, 0)
	s1 = v0
	
	for (a0 = 0; a0 < 0x00800000; a0 += 4)
	{
		v1 = -1
		sw v1, $0000(v0)
		v0 += 4
	}
	
	call decryptFile(:file_00, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_01, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_02, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_03, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_04, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_05, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_06, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_07, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_08, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_09, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_0a, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_0b, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_0c, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_0d, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call decryptFile(:file_0e, s1)
	call writeOutput(s0, s1, v0, v1)
	s0 = v0
	s1 = v1
	
	call hault()
}

fnc decryptFile(EE a0, EE a1) \s0,s1,s2,s3
{
	addiu sp, sp, $ff80
	s1 = sp
	sq zero, $0000(s1)
	
	//call memAlloc($40, $00800000, 0)
	s3 = a0
	s2 = a1
	
	call LoadMCPatchFile(1, s3, s2)
	s0 = v0
	if (s0 <= 0)
	{
		call hault()
	}
	
	call Decrypt_1(s0, s2, s1)
	if (v0 <> 0)
	{
		call hault()
	}
	
	lw a1, $0000(s1)
	call Decrypt_2(s0, a1, s2)
	if (v0 <> 0)
	{
		call hault()
	}
	
	/*
	nop
	nop
	nop
	nop
	
	setreg v0, :dumpWrite
	lw a0, $0000(s1)
	sw s2, $0000(v0) // Compressed Data
	sw a0, $0004(v0) // Compressed Size
	
	call hault()
	*/
	addiu sp, sp, $0080
	
	// Return compressed size
	lw a0, $0000(s1)
	v0 = a0
	v1 = s0
}

fnc hault(void)
{
	while (1)
	{
		nop
		nop
		nop
		nop
		nop
		nop
	}
}
dumpWrite:

addradd $100

// int malloc(int a, int size, int c)
extern $001848c0 memAlloc(EE a0, EE a1, EE a2)

// void free(int *data)
extern $001802d0 memFree(EE a0, EE a1, EE a2)

/*
Input:
	a0 = MC Pos? :: 1
	a1 = File Name (S3CORE, etc)
	a2 = &Dest
Output:
	v0 = Size
*/
extern $00184090 LoadMCPatchFile(EE a0, EE a1, EE a2)


/*
Input:
	a0 = Size
	a1 = &Data
	a2 = &NewSizeDest
Output:
	v0 = ZERO (Success)
*/
extern $009cc870 Decrypt_1(EE a0, EE a1, EE a2)

/*
Input:
	a0 = Size
	a1 = OutputSize
	a2 = &Data
Output:
	v0 = ZERO (Success)
*/
extern $009cd1b0 Decrypt_2(EE a0, EE a1, EE a2)
