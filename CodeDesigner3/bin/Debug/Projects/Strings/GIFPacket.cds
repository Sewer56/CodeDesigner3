/*
	GIF Packet Library
	Created by: Gtlcpimp
*/

//============================================================
// Draw String (Tiny Font)
/*
Input:
	a0 = &String
	a1 = Coordinate X
	a2 = Coordinate Y
	a3 = Color R
	t0 = Color G
	t1 = Color B
*/
fnc gif_DrawStringTF(EE a0, EE a1, EE a2, EE a3, EE t0, EE t1) \s0,s1,s2,s3,s4,s5,s6,s7,k0,k1,gp
{
	s0 = a0 // string
	
	s3 = a3 // r
	s4 = t0 // g
	s5 = t1 // b
	
	addiu sp, sp, $fff0
	s1 = sp
	sh a1, $0000(s1) // New X
	sh a2, $0002(s1) // New Y
	sh a1, $0004(s1) // Main X
	sh a2, $0006(s1) // Main Y
	
	
	lui v0, $0004
	subu sp, sp, v0
	s6 = sp
	
	addiu sp, sp, $ff80
	
	gp = 0
	
	while (1)
	{
		s7 = sp
		
		lb a0, $0000(s0)
		if (a0 == 0)
			break
		
		if (a0 == $0a)
		{
			lh v0, $0004(s1)
			sh v0, $0000(s1)
			lh v0, $0002(s1)
			v0 += 10
			sh v0, $0002(s1)
		}
		else if (a0 == $0d)
		{
			
		}
		else
		{
			call tinyFont_Deflate(a0, s7)
			
			for (k0 = 0; k0 < 10; k0++)
			{
				for (k1 = 0; k1 < 8; k1 += 2)
				{
					// k0 = offset y
					// k1 = offset x
					
					lb v0, $0000(s7)
					v0 >> 4
					andi v0, v0, 15
					if (v0 > 0)
					{
						lh t0, $0000(s1) // Get X
						lh t1, $0002(s1) // Get Y
						
						addu t0, t0, k1 // Offset our X
						addu t1, t1, k0 // Offset our Y
						t0 += 1
						call gif_AddPixel(s6, gp, 1, 1, t0, t1, zero, s3, s4, s5)
						gp = v0
						
					}
					lb v0, $0000(s7)
					andi v0, v0, 15
					if (v0 > 0)
					{
						lh t0, $0000(s1) // Get X
						lh t1, $0002(s1) // Get Y
						
						addu t0, t0, k1 // Offset our X
						addu t1, t1, k0 // Offset our Y
						call gif_AddPixel(s6, gp, 1, 1, t0, t1, zero, s3, s4, s5)
						gp = v0
						
					}
					s7++
				}
			}
			lh t0, $0000(s1)
			t0 += 10
			sh t0, $0000(s1)
		}
		
		if (gp > $30000)
		{
			call gs_dmaUpload(s6, gp)
			gp = 0
		}
		
		s0++
	}
	
	if (gp > 0)
	{
		call gs_dmaUpload(s6, gp)
	}
	
	addiu sp, sp, $0090
	lui v0, $0004
	addu sp, sp, v0
}

//============================================================
// Add Pixel
/*
Input:
	a0 = &Packet
	a1 = Size
	a2 = Width
	a3 = Height
	t0 = Coordinate X
	t1 = Coordinate Y
	t2 = Coordinate Z
	t3 = Color Red
	t4 = Color Green
	t5 = Color Blue
Output:
	v0 = New Size
*/
fnc gif_AddPixel(EE a0, EE a1, EE a2, EE a3, EE t0, EE t1, EE t2, EE t3, EE t4, EE t5) \s0,s1,s2,s3,s4,s5,s6,s7,k0,k1
{
	s0 = a0 // &Packet
	s1 = a1 // Size
	s2 = a2 // Width
	s3 = a3 // Height
	s4 = t0 // X
	s5 = t1 // Y
	s6 = t2 // Z
	s7 = t3 // R
	k0 = t4 // G
	k1 = t5 // B
	
	s0 += s1
	s4 += 1730
	s5 += 1825
	
	andi s7, s7, 255
	andi k0, k0, 255
	andi k1, k1, 255
	
	// t0 GIF_SET_TAG(4, 1, 0, 0, 0, 1);
	lui t0, $1000
	dsll32 t0, t0, 0
	ori t0, t0, $8004
	
	// t1 0x0E
	t1 = $e
	
	// t2 GIF_SET_PRIM(6, 0, 0, 0, 0, 0, 0, 0, 0);
	t2 = 6
	
	// t3 GIF_REG_PRIM;
	t3 = 0
	
	// t4 GIF_SET_RGBAQ(r, g, b, 0x80, 0x3F800000);
	setreg t4, $3f800001
	dsll32 t4, t4, 0
	v0 = $80 // A
	v0 << 8
	v0 += k1 // B
	v0 << 8
	v0 += k0 // G
	v0 << 8
	v0 += s7 // R
	daddu t4, t4, v0
	
	// t5 GIF_REG_RGBAQ;
	t5 = 1
	
	// t6 GIF_SET_XYZ( NewX << 4, NewY << 4, z);
	v0 = s5 // NewY
	v0 << 16
	v0 += s4 // NewX
	v0 << 4
	t6 = s6 // Z
	dsll32 t6, t6, 0
	if (v0 < 0)
	{
		v1 = 1
		dsll32 v1, v1, 0
		daddu v0, v1, v0
	}
	daddu t6, t6, v0
	
	// t7 GIF_REG_XYZ2;
	t7 = 5
	
	// t8 GIF_SET_XYZ( (NewX + w) << 4, (NewY + h) << 4, z);
	daddu v0, s5, s3 // NewY += Height
	v0 << 16
	daddu v1, s4, s2 // NewX += Width
	daddu v0, v0, v1
	v0 << 4
	t8 = s6
	dsll32 t8, t8, 0
	if (v0 < 0)
	{
		v1 = 1
		dsll32 v1, v1, 0
		daddu v0, v1, v0
	}
	daddu t8, t8, v0
	
	// t9 GIF_REG_XYZ2;
	t9 = 5
	
	//--------------------- Accelerate Store
	lui a0, $2000
	s0 <<32 4
	s0 >>32 4
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
	
	v0 = s1
	v0 += $50
}

//============================================================
// Create Packet
/*
Input:
	a0 = Destination Address
	a1 = Pixel Count
Output:
	v0 = Packet Size
*/
fnc gif_CreatePacket(EE a0, EE a1) \s0,s1,s2
{
	s0 = a0
	s1 = a1
	s2 = 0
	for (s2 = 0; s2 < s1; s2++)
	{
		call gif_AddPixel(s0,s2,0,0,0,0,0,0,0,0)
		s0 += v0
		s2 += v0
	}
	v0 = s2
}

//============================================================
// Set Pixel
/*
Input:
	a0 = &Packet
	a1 = Index
	a2 = Width
	a3 = Height
	t0 = Coordinate X
	t1 = Coordinate Y
	t2 = Coordinate Z
	t3 = Color Red
	t4 = Color Green
	t5 = Color Blue
*/
fnc gif_SetPixel(EE a0, EE a1, EE a2, EE a3, EE t0, EE t1, EE t2, EE t3, EE t4, EE t5)
{
	
}
















