/*
	TinyFont Library
	Created by: Gtlcpimp
*/

//============================================================
// Decompress Font Character
/*
Input:
	a0 = Character Ascii
	a1 = Destination Address
*/
fnc tinyFont_Deflate(EE a0, EE a1) \s0,s1,s2
{
	setreg s0, :_TinyFont_Characters
	s1 = a1
	
	v0 = 12
	multu v0, a0, v0
	s0 += v0
	
	for (s2 = 10; s2 > 0; s2--)
	{
		lbu a0, $0000(s0)
		call _tinyFont_ByteToBIN(a0)
		
		sw v0, $0000(s1)
		
		s0++
		s1 += 4
	}
}

//============================================================
// Byte to BIN (Imported from lib MATH)
/*
Input:
	a0 = Byte
Output:
	v0 = Binary
*/
fnc _tinyFont_ByteToBIN(EE a0)
{
	v0 = 0
	v1 = 128
	for (a1 = 7; a1 >= 0; a1--)
	{
		v0 << 4
		and a2, a0, v1
		srlv a2, a2, a1
		v0 += a2
		v1 >> 1
	}
}

//============================================================
_TinyFont_Characters:

_TinyFont_Char_00:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_01:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_02:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_03:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_04:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_05:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_06:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_07:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_08:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_09:
hexcode $00000000
hexcode $00000000
hexcode $00000000

_TinyFont_Char_0A:
hexcode $00000000
hexcode $00000000
hexcode $00000000

_TinyFont_Char_0B:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_0C:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_0D:
hexcode $00000000
hexcode $00000000
hexcode $00000000

_TinyFont_Char_0E:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_0F:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_10:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_11:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_12:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_13:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_14:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_15:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_16:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_17:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_18:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_19:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_1A:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_1B:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_1C:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_1D:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_1E:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_1F:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_20:
hexcode $00000000
hexcode $00000000
hexcode $00000000

_TinyFont_Char_21:
hexcode $08080000
hexcode $00080808
hexcode $00000008

_TinyFont_Char_22:
hexcode $12121200
hexcode $00000000
hexcode $00000000

_TinyFont_Char_23:
hexcode $28280000
hexcode $0A3F143E
hexcode $0000000A

_TinyFont_Char_24:
hexcode $0A3C0800
hexcode $2828180E
hexcode $0000081E

_TinyFont_Char_25:
hexcode $25420000
hexcode $52542A15
hexcode $00000021

_TinyFont_Char_26:
hexcode $0A040000
hexcode $3149460A
hexcode $0000003E

_TinyFont_Char_27:
hexcode $08080800
hexcode $00000000
hexcode $00000000

_TinyFont_Char_28:
hexcode $04083000
hexcode $04040404
hexcode $00300804

_TinyFont_Char_29:
hexcode $10080600
hexcode $10101010
hexcode $00060810

_TinyFont_Char_2A:
hexcode $36080000
hexcode $0000140C
hexcode $00000000

_TinyFont_Char_2B:
hexcode $08000000
hexcode $08083E08
hexcode $00000008

_TinyFont_Char_2C:
hexcode $00000000
hexcode $0C000000
hexcode $0004080C

_TinyFont_Char_2D:
hexcode $00000000
hexcode $00003E00
hexcode $00000000

_TinyFont_Char_2E:
hexcode $00000000
hexcode $0C000000
hexcode $0000000C

_TinyFont_Char_2F:
hexcode $30204000
hexcode $04080810
hexcode $00010206

_TinyFont_Char_30:
hexcode $221C0000
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_31:
hexcode $0A0C0000
hexcode $08080808
hexcode $0000003E

_TinyFont_Char_32:
hexcode $100E0000
hexcode $02040810
hexcode $0000001E

_TinyFont_Char_33:
hexcode $101E0000
hexcode $10100C10
hexcode $0000000E

_TinyFont_Char_34:
hexcode $18100000
hexcode $103E1214
hexcode $00000010

_TinyFont_Char_35:
hexcode $021E0000
hexcode $10100E02
hexcode $0000000E

_TinyFont_Char_36:
hexcode $04380000
hexcode $22261A02
hexcode $0000001C

_TinyFont_Char_37:
hexcode $103E0000
hexcode $04040810
hexcode $00000002

_TinyFont_Char_38:
hexcode $221C0000
hexcode $22221C12
hexcode $0000001C

_TinyFont_Char_39:
hexcode $221C0000
hexcode $10203C22
hexcode $0000000E

_TinyFont_Char_3A:
hexcode $0C000000
hexcode $0C00000C
hexcode $0000000C

_TinyFont_Char_3B:
hexcode $0C000000
hexcode $0C00000C
hexcode $0004080C

_TinyFont_Char_3C:
hexcode $20000000
hexcode $18060618
hexcode $00000020

_TinyFont_Char_3D:
hexcode $00000000
hexcode $007F007F
hexcode $00000000

_TinyFont_Char_3E:
hexcode $01000000
hexcode $06181806
hexcode $00000001

_TinyFont_Char_3F:
hexcode $221E0000
hexcode $00081020
hexcode $00000008

_TinyFont_Char_40:
hexcode $223C0000
hexcode $027D2539
hexcode $0000001C

_TinyFont_Char_41:
hexcode $14080000
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_42:
hexcode $221E0000
hexcode $22221E22
hexcode $0000001E

_TinyFont_Char_43:
hexcode $023C0000
hexcode $02010101
hexcode $0000003C

_TinyFont_Char_44:
hexcode $221E0000
hexcode $22222222
hexcode $0000001E

_TinyFont_Char_45:
hexcode $023E0000
hexcode $02021E02
hexcode $0000003E

_TinyFont_Char_46:
hexcode $023E0000
hexcode $02021E02
hexcode $00000002

_TinyFont_Char_47:
hexcode $023C0000
hexcode $22213101
hexcode $0000003C

_TinyFont_Char_48:
hexcode $22220000
hexcode $22223E22
hexcode $00000022

_TinyFont_Char_49:
hexcode $083E0000
hexcode $08080808
hexcode $0000003E

_TinyFont_Char_4A:
hexcode $101C0000
hexcode $10101010
hexcode $0000000E

_TinyFont_Char_4B:
hexcode $12220000
hexcode $120A060A
hexcode $00000022

_TinyFont_Char_4C:
hexcode $02020000
hexcode $02020202
hexcode $0000003E

_TinyFont_Char_4D:
hexcode $33330000
hexcode $252D2D2B
hexcode $00000021

_TinyFont_Char_4E:
hexcode $26220000
hexcode $32322A2E
hexcode $00000022

_TinyFont_Char_4F:
hexcode $211E0000
hexcode $21212121
hexcode $0000001E

_TinyFont_Char_50:
hexcode $221E0000
hexcode $02021E22
hexcode $00000002

_TinyFont_Char_51:
hexcode $211E0000
hexcode $21212121
hexcode $0060301E

_TinyFont_Char_52:
hexcode $110F0000
hexcode $11090F11
hexcode $00000021

_TinyFont_Char_53:
hexcode $023C0000
hexcode $20201C02
hexcode $0000001E

_TinyFont_Char_54:
hexcode $087F0000
hexcode $08080808
hexcode $00000008

_TinyFont_Char_55:
hexcode $22220000
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_56:
hexcode $22410000
hexcode $14142222
hexcode $00000008

_TinyFont_Char_57:
hexcode $49410000
hexcode $32365649
hexcode $00000022

_TinyFont_Char_58:
hexcode $22410000
hexcode $22140814
hexcode $00000041

_TinyFont_Char_59:
hexcode $22410000
hexcode $08080814
hexcode $00000008

_TinyFont_Char_5A:
hexcode $203F0000
hexcode $02040810
hexcode $0000003F

_TinyFont_Char_5B:
hexcode $04041C00
hexcode $04040404
hexcode $001C0404

_TinyFont_Char_5C:
hexcode $02020100
hexcode $10080804
hexcode $00402010

_TinyFont_Char_5D:
hexcode $08080E00
hexcode $08080808
hexcode $000E0808

_TinyFont_Char_5E:
hexcode $14080800
hexcode $00412236
hexcode $00000000

_TinyFont_Char_5F:
hexcode $00000000
hexcode $00000000
hexcode $00007F00

_TinyFont_Char_60:
hexcode $00000804
hexcode $00000000
hexcode $00000000

_TinyFont_Char_61:
hexcode $1C000000
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_62:
hexcode $1A020200
hexcode $22222226
hexcode $0000001E

_TinyFont_Char_63:
hexcode $3C000000
hexcode $02020202
hexcode $0000003C

_TinyFont_Char_64:
hexcode $3C202000
hexcode $22222222
hexcode $0000003C

_TinyFont_Char_65:
hexcode $1C000000
hexcode $02023E22
hexcode $0000003C

_TinyFont_Char_66:
hexcode $7E087000
hexcode $08080808
hexcode $00000008

_TinyFont_Char_67:
hexcode $3C000000
hexcode $22222222
hexcode $001C203C

_TinyFont_Char_68:
hexcode $3A020200
hexcode $22222226
hexcode $00000022

_TinyFont_Char_69:
hexcode $0E000800
hexcode $08080808
hexcode $00000008

_TinyFont_Char_6A:
hexcode $1C001000
hexcode $10101010
hexcode $000E1010

_TinyFont_Char_6B:
hexcode $22020200
hexcode $120A0E12
hexcode $00000022

_TinyFont_Char_6C:
hexcode $08080E00
hexcode $08080808
hexcode $00000008

_TinyFont_Char_6D:
hexcode $6D000000
hexcode $4949495B
hexcode $00000049

_TinyFont_Char_6E:
hexcode $3A000000
hexcode $22222226
hexcode $00000022

_TinyFont_Char_6F:
hexcode $1C000000
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_70:
hexcode $1A000000
hexcode $22222226
hexcode $0002021E

_TinyFont_Char_71:
hexcode $3C000000
hexcode $22222222
hexcode $0020203C

_TinyFont_Char_72:
hexcode $3A000000
hexcode $02020226
hexcode $00000002

_TinyFont_Char_73:
hexcode $1E000000
hexcode $10180602
hexcode $0000000E

_TinyFont_Char_74:
hexcode $3E040000
hexcode $04040404
hexcode $00000038

_TinyFont_Char_75:
hexcode $22000000
hexcode $32222222
hexcode $0000002E

_TinyFont_Char_76:
hexcode $41000000
hexcode $14142222
hexcode $00000008

_TinyFont_Char_77:
hexcode $41000000
hexcode $36555549
hexcode $00000022

_TinyFont_Char_78:
hexcode $21000000
hexcode $120C0C12
hexcode $00000021

_TinyFont_Char_79:
hexcode $41000000
hexcode $14142222
hexcode $00070C08

_TinyFont_Char_7A:
hexcode $3E000000
hexcode $04081020
hexcode $0000003E

_TinyFont_Char_7B:
hexcode $08083000
hexcode $08080C08
hexcode $00300808

_TinyFont_Char_7C:
hexcode $08080800
hexcode $08080808
hexcode $00080808

_TinyFont_Char_7D:
hexcode $08080600
hexcode $08081808
hexcode $000E0808

_TinyFont_Char_7E:
hexcode $00000000
hexcode $00394E00
hexcode $00000000

_TinyFont_Char_7F:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_80:
hexcode $221C0000
hexcode $220F020F
hexcode $0000001C

_TinyFont_Char_81:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_82:
hexcode $00000000
hexcode $0C000000
hexcode $0004080C

_TinyFont_Char_83:
hexcode $3C080838
hexcode $08080808
hexcode $000E0808

_TinyFont_Char_84:
hexcode $00000000
hexcode $00000000
hexcode $00121212

_TinyFont_Char_85:
hexcode $00000000
hexcode $00000000
hexcode $0000002A

_TinyFont_Char_86:
hexcode $08080000
hexcode $0808083E
hexcode $00080808

_TinyFont_Char_87:
hexcode $08080000
hexcode $3E08083E
hexcode $00080808

_TinyFont_Char_88:
hexcode $0000120C
hexcode $00000000
hexcode $00000000

_TinyFont_Char_89:
hexcode $0A120000
hexcode $2C2C080A
hexcode $0000002A

_TinyFont_Char_8A:
hexcode $023C0C12
hexcode $20201C02
hexcode $0000001E

_TinyFont_Char_8B:
hexcode $00000000
hexcode $08040810
hexcode $00000010

_TinyFont_Char_8C:
hexcode $097E0000
hexcode $09093909
hexcode $0000007E

_TinyFont_Char_8D:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_8E:
hexcode $203F0C12
hexcode $02040810
hexcode $0000003F

_TinyFont_Char_8F:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_90:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_91:
hexcode $0C040800
hexcode $0000000C
hexcode $00000000

_TinyFont_Char_92:
hexcode $080C0C00
hexcode $00000004
hexcode $00000000

_TinyFont_Char_93:
hexcode $12121200
hexcode $00000000
hexcode $00000000

_TinyFont_Char_94:
hexcode $12121200
hexcode $00000000
hexcode $00000000

_TinyFont_Char_95:
hexcode $00000000
hexcode $001C1C1C
hexcode $00000000

_TinyFont_Char_96:
hexcode $00000000
hexcode $00003E00
hexcode $00000000

_TinyFont_Char_97:
hexcode $00000000
hexcode $00007F00
hexcode $00000000

_TinyFont_Char_98:
hexcode $00001428
hexcode $00000000
hexcode $00000000

_TinyFont_Char_99:
hexcode $3A2F0000
hexcode $0000002A
hexcode $00000000

_TinyFont_Char_9A:
hexcode $1E000C12
hexcode $10180602
hexcode $0000000E

_TinyFont_Char_9B:
hexcode $00000000
hexcode $08100804
hexcode $00000004

_TinyFont_Char_9C:
hexcode $1E000000
hexcode $09093929
hexcode $0000003E

_TinyFont_Char_9D:
hexcode $121E0000
hexcode $12121212
hexcode $0000001E

_TinyFont_Char_9E:
hexcode $3E000C12
hexcode $04081020
hexcode $0000003E

_TinyFont_Char_9F:
hexcode $22410012
hexcode $08080814
hexcode $00000008

_TinyFont_Char_A0:
hexcode $00000000
hexcode $00000000
hexcode $00000000

_TinyFont_Char_A1:
hexcode $08000000
hexcode $08080800
hexcode $00000808

_TinyFont_Char_A2:
hexcode $1C080000
hexcode $1C0A0A0A
hexcode $00000008

_TinyFont_Char_A3:
hexcode $04180000
hexcode $04040E04
hexcode $0000001E

_TinyFont_Char_A4:
hexcode $1E210000
hexcode $211E1212
hexcode $00000000

_TinyFont_Char_A5:
hexcode $22410000
hexcode $3E083E14
hexcode $00000008

_TinyFont_Char_A6:
hexcode $08080800
hexcode $00000000
hexcode $00080808

_TinyFont_Char_A7:
hexcode $021C0000
hexcode $14121A06
hexcode $000E1018

_TinyFont_Char_A8:
hexcode $00000012
hexcode $00000000
hexcode $00000000

_TinyFont_Char_A9:
hexcode $211E0000
hexcode $212D252D
hexcode $0000001E

_TinyFont_Char_AA:
hexcode $1C1E0000
hexcode $00003E12
hexcode $00000000

_TinyFont_Char_AB:
hexcode $00000000
hexcode $140A1428
hexcode $00000028

_TinyFont_Char_AC:
hexcode $00000000
hexcode $20203F00
hexcode $00000000

_TinyFont_Char_AD:
hexcode $00000000
hexcode $00003E00
hexcode $00000000

_TinyFont_Char_AE:
hexcode $110E0000
hexcode $000E1117
hexcode $00000000

_TinyFont_Char_AF:
hexcode $0000007F
hexcode $00000000
hexcode $00000000

_TinyFont_Char_B0:
hexcode $14080000
hexcode $00000008
hexcode $00000000

_TinyFont_Char_B1:
hexcode $08000000
hexcode $08083E08
hexcode $0000003E

_TinyFont_Char_B2:
hexcode $183C0000
hexcode $0000003C
hexcode $00000000

_TinyFont_Char_B3:
hexcode $081C0000
hexcode $0000001C
hexcode $00000000

_TinyFont_Char_B4:
hexcode $00000810
hexcode $00000000
hexcode $00000000

_TinyFont_Char_B5:
hexcode $22000000
hexcode $32222222
hexcode $0002022E

_TinyFont_Char_B6:
hexcode $2E3E0000
hexcode $28282C2E
hexcode $00282828

_TinyFont_Char_B7:
hexcode $00000000
hexcode $000C0C00
hexcode $00000000

_TinyFont_Char_B8:
hexcode $00000000
hexcode $00000000
hexcode $00181000

_TinyFont_Char_B9:
hexcode $080C0000
hexcode $00000008
hexcode $00000000

_TinyFont_Char_BA:
hexcode $120C0000
hexcode $00000C12
hexcode $00000000

_TinyFont_Char_BB:
hexcode $00000000
hexcode $1428140A
hexcode $0000000A

_TinyFont_Char_BC:
hexcode $0A130000
hexcode $7A2A340A
hexcode $00000021

_TinyFont_Char_BD:
hexcode $0A130000
hexcode $2242740A
hexcode $00000071

_TinyFont_Char_BE:
hexcode $23470000
hexcode $7A2C3817
hexcode $00000021

_TinyFont_Char_BF:
hexcode $08000000
hexcode $04080800
hexcode $003C2202

_TinyFont_Char_C0:
hexcode $14080402
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_C1:
hexcode $14080810
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_C2:
hexcode $1408120C
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_C3:
hexcode $14081428
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_C4:
hexcode $14080012
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_C5:
hexcode $14081408
hexcode $223E2214
hexcode $00000041

_TinyFont_Char_C6:
hexcode $0C380000
hexcode $0E0A1A0C
hexcode $00000039

_TinyFont_Char_C7:
hexcode $023C0000
hexcode $02010101
hexcode $0018103C

_TinyFont_Char_C8:
hexcode $023E0804
hexcode $02021E02
hexcode $0000003E

_TinyFont_Char_C9:
hexcode $023E1020
hexcode $02021E02
hexcode $0000003E

_TinyFont_Char_CA:
hexcode $023E120C
hexcode $02021E02
hexcode $0000003E

_TinyFont_Char_CB:
hexcode $023E0012
hexcode $02021E02
hexcode $0000003E

_TinyFont_Char_CC:
hexcode $083E0804
hexcode $08080808
hexcode $0000003E

_TinyFont_Char_CD:
hexcode $083E0810
hexcode $08080808
hexcode $0000003E

_TinyFont_Char_CE:
hexcode $083E120C
hexcode $08080808
hexcode $0000003E

_TinyFont_Char_CF:
hexcode $083E0012
hexcode $08080808
hexcode $0000003E

_TinyFont_Char_D0:
hexcode $221E0000
hexcode $22222722
hexcode $0000001E

_TinyFont_Char_D1:
hexcode $26221428
hexcode $32322A2E
hexcode $00000022

_TinyFont_Char_D2:
hexcode $211E0804
hexcode $21212121
hexcode $0000001E

_TinyFont_Char_D3:
hexcode $211E0810
hexcode $21212121
hexcode $0000001E

_TinyFont_Char_D4:
hexcode $211E120C
hexcode $21212121
hexcode $0000001E

_TinyFont_Char_D5:
hexcode $211E1428
hexcode $21212121
hexcode $0000001E

_TinyFont_Char_D6:
hexcode $211E0012
hexcode $21212121
hexcode $0000001E

_TinyFont_Char_D7:
hexcode $21000000
hexcode $120C0C12
hexcode $00000021

_TinyFont_Char_D8:
hexcode $333E0000
hexcode $33252529
hexcode $0000001F

_TinyFont_Char_D9:
hexcode $22220804
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_DA:
hexcode $22221020
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_DB:
hexcode $2222120C
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_DC:
hexcode $22220012
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_DD:
hexcode $22411020
hexcode $08080814
hexcode $00000008

_TinyFont_Char_DE:
hexcode $1E020000
hexcode $1E222222
hexcode $00000002

_TinyFont_Char_DF:
hexcode $12121C00
hexcode $22120A0A
hexcode $0000003A

_TinyFont_Char_E0:
hexcode $1C000804
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_E1:
hexcode $1C000810
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_E2:
hexcode $1C00120C
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_E3:
hexcode $1C001428
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_E4:
hexcode $1C001400
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_E5:
hexcode $1C081408
hexcode $22223C20
hexcode $0000007C

_TinyFont_Char_E6:
hexcode $37000000
hexcode $09093E28
hexcode $00000036

_TinyFont_Char_E7:
hexcode $3C000000
hexcode $02020202
hexcode $0018103C

_TinyFont_Char_E8:
hexcode $1C000804
hexcode $02023E22
hexcode $0000003C

_TinyFont_Char_E9:
hexcode $1C000810
hexcode $02023E22
hexcode $0000003C

_TinyFont_Char_EA:
hexcode $1C00120C
hexcode $02023E22
hexcode $0000003C

_TinyFont_Char_EB:
hexcode $1C001400
hexcode $02023E22
hexcode $0000003C

_TinyFont_Char_EC:
hexcode $0E000804
hexcode $08080808
hexcode $00000008

_TinyFont_Char_ED:
hexcode $0E000810
hexcode $08080808
hexcode $00000008

_TinyFont_Char_EE:
hexcode $0E00120C
hexcode $08080808
hexcode $00000008

_TinyFont_Char_EF:
hexcode $0E001400
hexcode $08080808
hexcode $00000008

_TinyFont_Char_F0:
hexcode $1C120E00
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_F1:
hexcode $3A001428
hexcode $22222226
hexcode $00000022

_TinyFont_Char_F2:
hexcode $1C000804
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_F3:
hexcode $1C000408
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_F4:
hexcode $1C00120C
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_F5:
hexcode $1C001428
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_F6:
hexcode $1C001400
hexcode $22222222
hexcode $0000001C

_TinyFont_Char_F7:
hexcode $04000000
hexcode $00003F00
hexcode $00000004

_TinyFont_Char_F8:
hexcode $3C000000
hexcode $26262A32
hexcode $0000001E

_TinyFont_Char_F9:
hexcode $22000804
hexcode $32222222
hexcode $0000002E

_TinyFont_Char_FA:
hexcode $22000408
hexcode $32222222
hexcode $0000002E

_TinyFont_Char_FB:
hexcode $2200120C
hexcode $32222222
hexcode $0000002E

_TinyFont_Char_FC:
hexcode $22001400
hexcode $32222222
hexcode $0000002E

_TinyFont_Char_FD:
hexcode $41000810
hexcode $14142222
hexcode $00070C08

_TinyFont_Char_FE:
hexcode $1A020200
hexcode $22222226
hexcode $0002021E

_TinyFont_Char_FF:
hexcode $41001400
hexcode $14142222
hexcode $00070C08