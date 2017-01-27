/*
	Math Library
	Created by: Gtlcpimp
*/

//============================================================
// Get Float Full Value - Returns word with fraction
/*
Input:
	f0 = Float to convert
Output:
	v0 = Whole Number (Left side of decimal)
	v1 = Fraction (Right side of decimal)
*/
fnc math_FloatToWord(COP1 $f0) \f0,f1
{
	/*
	a0 = 1234
	a1 = 5
	mtc1 a0, $f0
	mtc1 a1, $f1
	cvt.s.w $f0, $f0
	cvt.s.w $f1, $f1
	div.s $f0, $f0, $f1
	mfc1 a0, $f0
	*/
	
	cvt.w.s $f1, $f0
	mfc1 v0, $f1
	
	mtc1 v0, $f1
	cvt.s.w $f1, $f1
	sub.s $f0, $f0, $f1
	
	mfc1 v1, $f0
	while (v1)
	{
		lui v1, $4120
		mtc1 v1, $f1
		mul.s $f0, $f0, $f1
		
		cvt.w.s $f1, $f0
		cvt.s.w $f1, $f1
		sub.s $f1, $f0, $f1
		
		mfc1 v1, $f1
	}
	
	cvt.w.s $f0, $f0
	mfc1 v1, $f0
}
