/*
	Graphics Library
	Created by: Gtlcpimp
*/

//============================================================
// Vertical Sync
fnc gs_vSync(void)
{
	lui a0, $1200
	v1 = 8
	
	ld v0, $1000(a0)
	or v0, v0, v1
	sd v0, $1000(a0)
	
	while (v0)
	{
		ld v0, $1000(v0)
		and v0, v0, v1
	}
	
}

//============================================================
// Get Display
fnc gs_GetDisplay(void)
{
	lui a0, $1200
	ld v0, $0080(a0) // Display 1
	ld v1, $00a0(a0) // Display 2
}

//============================================================
// Set Display
fnc gs_RestoreDisplay(EE a0, EE a1)
{
	lui v0, $1200
	sd a0, $0080(v0) // Display 1
	sd a1, $00a0(v0) // Display 2
}

//============================================================
// Set Display
// -> GS_SET_DISPLAY(632, 50, 3, 0, 2559, 447)
fnc gs_SetDisplay(void)
{
	lui a0, $1200
	
	setreg v0, $001bf9ff
	setreg v1, $01832278
	dsll32 v0, v0, 0
	daddu v0, v0, v1
	
	sd v0, $0080(a0) // Display 1
	sd v0, $00a0(a0) // Display 2
}

//============================================================
// Initialize Screen
/*
Input:
	a0 = Background Color R
	a1 = Background Color G
	a2 = Background Color B
*/
fnc gs_InitScreen(EE a0, EE a1, EE a2) \s0,s1,s2,s3
{
	s0 = a0
	s1 = a1
	s2 = a2
	
	//---------------------------- Fully Flush
	for (s3 = 0; s3 < 50; s3++)
	{
		call gs_SetDisplayBuffer()
		call gs_SetDrawBuffer()
		call gs_SetZBuffer()
		call gs_ClearBuffer(s0, s1, s2)
		call gs_vSync()
	}
}

//============================================================
// Set Display Buffer
fnc gs_SetDisplayBuffer(void)
{
	lui a0, $1200
	
	v0 = $1400
	sd v0, $0070(a0)
	sd v0, $0090(a0)
	
}
//============================================================
// Set Draw Buffer
fnc gs_SetDrawBuffer(void) \s0
{
	addiu sp, sp, $ff80
	s0 = sp
	
	// t0 *(u64*)pckt = GIF_SET_TAG(5, 1, 0, 0, GIF_TAG_PACKED, 1);
	lui t0, $1000
	ori v0, zero, $8005
	dsll32 t0, t0, 0
	daddu t0, t0, v0
	
	// t1 *(u64*)pckt = 0xE;
	t1 = $e
	
	// t2 *(u64*)pckt = GIF_SET_FRAME(0, 10, 32, 0);
	lui t2, $200a
	
	// t3 *(u64*)pckt = GIF_REG_FRAME_1;
	t3 = $4c
	
	// t4 *(u64*)pckt = GIF_SET_SCISSOR(0, 639, 0, 447);
	lui t4, $01bf
	lui v0, $027f
	dsll32 t4, t4, 0
	daddu t4, t4, v0
	
	// t5 *(u64*)pckt = GIF_REG_SCISSOR_1;
	t5 = $40
	
	// t6 *(u64*)pckt = GIF_SET_TEST(0, 0, 0, 0, 0, 0, 1, 2);
	lui t6, $0005
	
	// t7 *(u64*)pckt = GIF_REG_TEST_1;
	t7 = $47
	
	// t8 *(u64*)pckt = GIF_SET_XYOFFSET(1728 << 4, 1824 << 4);
	t8 = $7200
	v0 = $6c00
	dsll32 t8, t8, 0
	daddu t8, t8, v0
	
	// t9 *(u64*)pckt = GIF_REG_XYOFFSET_1;
	t9 = $18
	
	// v0 *(u64*)pckt = GIF_SET_PRMODECONT(1);
	v0 = 1
	
	// v1 *(u64*)pckt = GIF_REG_PRMODECONT;
	v1 = $1a
	
	
	//----------------- Accelerated store
	dsll32 s0, s0, 4
	dsrl32 s0, s0, 4
	lui a0, $2000
	addu s0, s0, a0
	
	sd t0, $0000(s0)
	sd t1, $0008(s0)
	sd t2, $0010(s0)
	sd t3, $0018(s0)
	sd t4, $0020(s0)
	sd t5, $0028(s0)
	sd t6, $0030(s0)
	sd t7, $0038(s0)
	sd t8, $0040(s0)
	sd t9, $0048(s0)
	sd v0, $0050(s0)
	sd v1, $0058(s0)
	
	//addiu a1, s0, $60
	//call gs_SyncDCache(s0, a1)
	
	call gs_dmaUpload(s0, $60)
	
	addiu sp, sp, $0080
}

//============================================================
// Set Z Buffer
fnc gs_SetZBuffer(void) \s0
{
	addiu sp, sp, $ffc0
	s0 = sp
	
	// t0 *(u64*)pckt = GIF_SET_TAG(1, 1, 0, 0, 0, 1);
	lui t0, $1000
	dsll32 t0, t0, 0
	setreg v0, $00008001
	daddu t0, t0, v0
	
	// t1 *(u64*)pckt = 0xE;
	t1 = $e
	
	// t2 *(u64*)pckt = GIF_SET_ZBUF(0x96, 32, 0);
	t2 = $96
	
	// t3 *(u64*)pckt = GIF_REG_ZBUF_1;
	t3 = $4e
	
	//----------------- Accelerated store
	dsll32 s0, s0, 4
	dsrl32 s0, s0, 4
	lui a0, $2000
	addu s0, s0, a0
	
	sd t0, $0000(s0)
	sd t1, $0008(s0)
	sd t2, $0010(s0)
	sd t3, $0018(s0)
	
	//addiu a1, s0, $20
	//call gs_SyncDCache(s0, a1)
	
	call gs_dmaUpload(s0, $20)
	
	addiu sp, sp, $0040
}
//============================================================
// Clear Buffer
/*
Input:
	a0 = Background Color R
	a1 = Background Color G
	a2 = Background Color B
*/
fnc gs_ClearBuffer(EE a0, EE a1, EE a2) \s0,s1,s2,s3
{
	
	// t0 *(u64*)pckt = GIF_SET_TAG(6, 1, 0, 0, 0, 1);
	lui t0, $1000
	ori v0, zero, $8006
	dsll32 t0, t0, 0
	daddu t0, t0, v0
	
	// t1 *(u64*)pckt = 0xE;
	t1 = $e
	
	// t2 *(u64*)pckt = GIF_SET_TEST(0, 0, 0, 0, 0, 0, 1, 1);
	lui t2, $0003
	
	// t3 *(u64*)pckt = GIF_REG_TEST_1;
	t3 = $47
	
	// t4 *(u64*)pckt = GIF_SET_PRIM(6, 0, 0, 0, 0, 0, 0, 0, 0);
	t4 = 6
	
	// t5 = *(u64*)pckt = GIF_REG_PRIM;
	t5 = 0
	
	// t6 *(u64*)pckt = GIF_SET_RGBAQ(0x12, 0x34, 0x56, 0x80, 0x3F800000);
	setreg t6, $3f800001
	dsll32 t6, t6, 0
	lui v0, $8000 // A
	a2 << 16
	a1 << 8
	addu v0, v0, a2 // B
	addu v0, v0, a1 // G
	addu v0, v0, a0 // R
	// v0 = aabbggrr
	daddu t6, t6, v0
	// t6 = 3f800000 80ffffff
	
	// t7 *(u64*)pckt = GIF_REG_RGBAQ;
	t7 = 1
	
	// t8 *(u64*)pckt = GIF_SET_XYZ(0x0000, 0x0000, 0x0000);
	t8 = 0
	
	// t9 *(u64*)pckt = GIF_REG_XYZ2;
	t9 = 5
	
	// *(u64*)pckt = GIF_SET_XYZ(0xFFFF, 0xFFFF, 0x0000);
	s0 = 1
	dsll32 s0, s0, 0
	daddiu s0, s0, -1
	// s0 = 00000000 ffffffff
	
	// s1 *(u64*)pckt = GIF_REG_XYZ2;
	s1 = 5
	
	// s2 *(u64*)pckt = GIF_SET_TEST(0, 0, 0, 0, 0, 0, 1, 2);
	s2 = 5
	
	// s3 *(u64*)pckt = GIF_REG_TEST_1;
	s3 = $47
	
	addiu sp, sp, $ff80
	a0 = sp
	dsll32 a0, a0, 4
	dsrl32 a0, a0, 4
	lui a1, $2000
	addu a0, a0, a1
	
	sd t0, $0000(a0)
	sd t1, $0008(a0)
	sd t2, $0010(a0)
	sd t3, $0018(a0)
	sd t4, $0020(a0)
	sd t5, $0028(a0)
	sd t6, $0030(a0)
	sd t7, $0038(a0)
	sd t8, $0040(a0)
	sd t9, $0048(a0)
	sd s0, $0050(a0)
	sd s1, $0058(a0)
	sd s2, $0060(a0)
	sd s3, $0068(a0)
	s0 = a0
	addiu a1, s0, $70
	
	//call gs_SyncDCache(a0, a1)
	
	call gs_dmaUpload(s0, $70)
	
	addiu sp, sp, $0080
}
//============================================================
// DMA Channel 2 Upload (Send GIF Packet)
/*
Input:
	a0 = &Packet
	a1 = Size
*/
fnc gs_dmaUpload(EE a0, EE a1) \s0,s1
{
	s0 = a0
	s1 = a1
	
	call gs_dmaWait() // Wait for CH2 to be Ready
	
	setreg a0, $1000a000
	
	// 0000 = Initialize Transfer (0x0181)
	// 0010 = Memory Address
	// 0020 = Quad Size
	//---------------------------- Set Data Address
	sw s0, $0010(a0)
	
	//---------------------------- Set Quad Size
	addiu v0, s1, 15
	v0 >> 4
	ori v1, zero, -1
	and v0, v0, v1
	sw v0, $0020(a0)
	
	//---------------------------- Start Data Transfer
	v0 = $181
	sw v0, $0000(a0)
}

//============================================================
// Wait for DMA Channel 2 to be ready
fnc gs_dmaWait(void)
{
	setreg a0, $1000a000
	
	lw v0, $0000(a0)
	while (v0)
	{
		lw v0, $0000(a0)
		v1 = $100
		and v0, v0, v1
	}
}
