// Some simple modeling of CHUC rents and yearly incomes.

open System;

// Parameters
let years = 30;
let inflation = 0.03;
let inflationAtYear year = Math.Pow (1.0 + inflation, float year);

let initialRent = 3500.0;

// Months start from one.
let asYear month = (month-1) / 12;

// Rent paid every single month, as a list
let rentAtMonth year0Rent month =
    year0Rent * inflationAtYear (asYear month);

[<EntryPoint>]
let main argv = 
    printfn "%d" (int (rentAtMonth 3500.0 13))
    0 // return an integer exit code
