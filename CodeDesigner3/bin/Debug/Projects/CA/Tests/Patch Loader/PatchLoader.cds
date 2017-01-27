address $00183fd0

addu v0, s0, s2
lw s2, $fffc(v0)

a0 = s3 // Destination
addiu a1, sp, $0080 // Stack for Return Size
a2 = s0 // &Data
a3 = s2 // Compressed Size


jal $001f6470
nop

goto $00184020



address $002ebf78
//a0 = size; a1 = addr;  a2 = &stack
s2 -= 4
addu a1, a1, s2
lw a0, $0000(a1)
sw a0, $006c(sp)
goto $002ebfa0


address $0019bf54
//a0 = size; a1 = addr;  a2 = &stack
s1 -= 4
addu a0, s4, s1
lw v0, $0000(a0)
sw v0, $0000(sp)
v0 = 0
goto $0019bfa8





//a0 = sizeB; a1 = outputSize; a2 = &data