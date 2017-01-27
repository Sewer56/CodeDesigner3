address $00183730
jal :loadCustomCDPatch

address $00090000

/*
Input:
	a0 = S3CORE (File Name)
	a1 = &Destination
	a2 = 0
Output:
	v0 = 1 (success)
*/
fnc loadCustomCDPatch(void) \s0,s1,s2,s3
{
	setreg s2, $001f6f00
	
	// malloc()8mb
	call memAlloc($40, $00800000, 0)
	s0 = v0
	
	// fioOpen();
	string ScusELF "cdrom0:\\SCUSNGUI.ELF;1"
	call fioOpen(:ScusELF, 1)
	s1 = v0
	
	// fioRead();
	call fioRead(s1, s0, 4860564)
	
	// fioClose();
	call fioClose(s1)
	
	// Decompress data
	setreg v0, $0fffffff
	and a0, s0, v0
	lui v0, $2000
	or a0, a0, v0
	call unpack(a0, s2, zero, 0x004e9d00)
	
	// free()
	call memFree(s0, zero, zero)
	
	
	// InitPatch()
	//call initPatch(0x001F6F00, 0x004E9D00)
	call Initialize(0x001F6F00, 0x004E9D00)
	v0 = 1
}

fnc Initialize(EE a0, EE a1) \s0,s1,s2,s3
{
	s0 = a0
	
	addu a1, s0, a1
	lw a2, $0014(s0)
	for (a0 = 0; a0 < a2; a0 += 1)
	{
		sb zero, $0000(a1)
	}
	
	lw s1, $0018(s0)
	lw s2, $001c(s0)
	while (s1 < s2)
	{
		lw v0, $0000(s1)
		jalr v0
		nop
		s1 += 4
	}
	
}

// void initPatch(int startPtr, int Size)
extern $00182230 initPatch(EE a0, EE a1)

// int malloc(int a, int size, int c)
extern $001848c0 memAlloc(EE a0, EE a1, EE a2)

// void free(int *data)
extern $001802d0 memFree(EE a0, EE a1, EE a2)

// int fioOpen(char *fileName, int fileMode)
extern $0018a328 fioOpen(EE a0, EE a1)

// int fioRead(int fileNumber, int destPtr, int size)
extern $0018a970 fioRead(EE a0, EE a1, EE a2)

// int fioClose(int fileNumber)
extern $0018a5b8 fioClose(EE a0)
