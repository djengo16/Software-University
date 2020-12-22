function getGreatestDivisor(first, second) {
    let greatestDivisor;
    if (first > second) {
        for (let index = second; index >= 0; index--) {
            if (first % index == 0 && second % index == 0) {
                greatestDivisor = index;
                break;
            }
        }
    } else {
        for (let index = first; index >= 0; index--) {
            if (first % index == 0 && second % index == 0) {
                greatestDivisor = index;
                break;
            }

        }
    }
    console.log(greatestDivisor);
}

getGreatestDivisor(2154, 458);