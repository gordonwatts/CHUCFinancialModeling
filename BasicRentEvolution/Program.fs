// Some simple modeling of CHUC rents and yearly incomes.

//#r "MathNet.Numerics.dll"
//#r "MatNet.Numerics.FSharp.dll"
open System;
open MathNet.Numerics.Distributions;

// Get some of the sequence generation setup.

let ran = Normal();
let ranSeq = ran.Samples();
let normalRescale (mean:float) (width:float) (x:float) = (x * width) + mean;
let normalRescaleSeq (mean:float) (width:float) = Seq.map(normalRescale mean width);


// Parameters
let years = 30;
let inflation = 0.03;

// Renters
let averageRenterStayYrs = 10.0;
let inflationAtYear year = Math.Pow (1.0 + inflation, float year);

let initialRent = 3500.0;

// Renter payment over the year
let averageRenterStayWidth = Math.Sqrt(averageRenterStayYrs);


// Months start from one.
let asYear month = (month-1) / 12;

// Rent paid every single month, as a list
let rentAtMonth year0Rent month =
    year0Rent * inflationAtYear (asYear month);

[<EntryPoint>]
let main argv = 
    printfn "%d" (int (rentAtMonth 3500.0 13))
    0 // return an integer exit code
