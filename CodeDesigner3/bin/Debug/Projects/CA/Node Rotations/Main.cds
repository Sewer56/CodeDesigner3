address $00637488
jal :test2

address $000c0000

fnc test2(void) \s0,s1,s2,s3
{
	setreg s0, :saved
	setreg s1, $018e7e50
	
	lwc1 f0, $0000(s0)
	setreg v0, $3CA3D70A
	mtc1 v0, f1
	
	lw v0, $0004(s0)
	if (v0 == 0)
	{
		add.s f0, f0, f1
		setreg v0, $47C35000
		mtc1 v0, f1
		mul.s f1, f1, f0
		cvt.w.s f1, f1
		mfc1 v0, f1
		if (v0 > 100000)
		{
			lui v0, $3f80
			mtc1 v0, f0
			addiu v0, zero, 1
			sw v0, $0004(s0)
		}
	}
	else
	{
		sub.s f0, f0, f1
		//abs.s f1, f0
		setreg v0, $47C35000
		mtc1 v0, f2
		mul.s f1, f0, f2
		cvt.w.s f1, f1
		mfc1 v0, f1
		if (v0 < -100000)
		{
			lui v0, $bf80
			mtc1 v0, f0
			sw zero, $0004(s0)
		}
	}
	swc1 f0, $0000(s0)
	
	mul.s f0, f0, f0
	lui v0, $3f80
	mtc1 v0, f1
	sub.s f2, f1, f0
	
	sqrt.s f2, f2
	sqrt.s f0, f0
	
	swc1 f2, $0008(s0)
	
	lw v0, $0004(s0)
	if (v0 == 1)
	{
		//mtc1 zero, f1
		neg.s f2, f2
	}
	
	//swc1 f0, $0010(s1)
	//swc1 f0, $0038(s1)
	
	swc1 f2, $0010(s1)
	swc1 f2, $0038(s1)
	
	lwc1 f0, $0000(s0)
	swc1 f0, $0018(s1)
	neg.s f0, f0
	swc1 f0, $0030(s1)
	
	
	//swc1 f2, $0018(s1)
	//neg.s f2, f2
	//swc1 f2, $0030(s1)
}


fnc nodeTests(void) \s0,s1,s2,s3
{
	setreg s0, :saved
	setreg s1, $018f1d60
	
	lwc1 f0, $0000(s0)
	
	setreg v0, $3C360B61
	mtc1 v0, f1
	add.s f0, f0, f1
	cvt.w.s f1, f0
	mfc1 v0, f1
	
	if (v0 >= 1)
		sw zero, $0000(s0)
	else
		swc1 f0, $0000(s0)
	
	mul.s f0, f0, f0
	lui v0, $3f80
	mtc1 v0, f1
	sub.s f2, f1, f0
	
	sqrt.s f2, f2
	sqrt.s f0, f0
	
	swc1 f2, $0010(s1)
	swc1 f2, $0038(s1)
	
	swc1 f0, $0018(s1)
	neg.s f0, f0
	swc1 f0, $0030(s1)
}
saved:
nop
nop