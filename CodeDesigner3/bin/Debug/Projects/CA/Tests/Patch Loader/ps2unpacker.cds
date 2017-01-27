
extern %thisaddr unpack(EE a0, EE a1, EE a2, EE a3)
//lui s2, $01D0
//lw s2, $0004(s2)
//lw s1, $000C(s2)
//addiu s0, s2, $0010
//lw s3, $0004(s2)

addiu sp, sp, $ff00
sq ra, $0000(sp)
sq s0, $0010(sp)
sq s1, $0020(sp)
sq s2, $0030(sp)
sq s3, $0040(sp)
sq s4, $0050(sp)

daddu t0, zero, zero
daddu t1, zero, zero
daddu t2, zero, zero
daddu t3, zero, zero
daddu t4, zero, zero
daddu t5, zero, zero
daddu t6, zero, zero
daddu t7, zero, zero
daddu t8, zero, zero
daddu t9, zero, zero
daddu v0, zero, zero
daddu v1, zero, zero

daddu s0, a0, zero // Compressed start
daddu s1, a1, zero // Data write
daddu s2, a2, zero // Entry
daddu s3, a3, zero // Decompressed size
//addu s4, s3, s1   

bgezal zero, :deflate_start //$0009
addu s4, s3, s1 // Write start + size
//lw s0, $0008(s2)

/*
sb zero, $0000(s4)
addiu s4, s4, $0001
bne s0, zero, -3
addiu s0, s0, $FFFF
*/

lq s0, $0010(sp)
lq s1, $0020(sp)
lq s2, $0030(sp)
lq s3, $0040(sp)
lq s4, $0050(sp)
lq ra, $0000(sp)
jr ra
addiu sp, sp, $0100

deflate_start:
daddu t9, ra, zero
daddu t0, zero, zero
addiu t2, zero, $0001
lui t6, $00FF
bgezal zero, $0046
nop
beq v0, zero, 6
addiu t3, zero, $0001
lbu t1, $0000(s0)
addiu s0, s0, $0001
sb t1, $0000(s1)
beq zero, zero, -8
addiu s1, s1, $0001
bgezal zero, $003D
sll t3, t3, 1
bgezal zero, $003B
addu t3, t3, v0
bne v0, zero, 5
addiu t3, t3, $FFFF
bgezal zero, $0037
sll t3, t3, 1
beq zero, zero, -9
addu t3, t3, v0
addiu t3, t3, $FFFF
bne t3, zero, 5
nop
bgezal zero, $0030
daddu t3, t2, zero
beq zero, zero, 14
daddu t4, v0, zero
addiu t3, t3, $FFFF
lbu t1, $0000(s0)
sll t3, t3, 8
addiu s0, s0, $0001
addu t3, t3, t1
addiu t1, t3, $0001
bne t1, zero, 2
nop
jr t9
andi t4, t1, $0001
srl t3, t3, 1
addiu t3, t3, $0001
daddu t2, t3, zero
bgezal zero, $001F
nop
beq t4, zero, 3
nop
beq zero, zero, 15
addiu t4, v0, $0003
bne v0, zero, 10
nop
addiu t4, t4, $0001
bgezal zero, $0016
sll t4, t4, 1
bgezal zero, $0014
addu t4, t4, v0
beq v0, zero, -5
nop
beq zero, zero, 4
addiu t4, t4, $0005
bgezal zero, $000E
nop
addiu t4, v0, $0005
sltiu t1, t3, $0501
subu t4, t4, t1
subu t5, s1, t3
lbu t1, $0000(t5)
addiu t5, t5, $0001
sb t1, $0000(s1)
nop
addiu t4, t4, $FFFF
bne t4, zero, -6
addiu s1, s1, $0001
beq zero, zero, -70
nop
and t1, t0, t6
bne t1, zero, 3
lbu t1, $0000(s0)
addiu s0, s0, $0001
or t0, t1, t6
srl v0, t0, 7
sll t0, t0, 1
jr ra
andi v0, v0, $0001
