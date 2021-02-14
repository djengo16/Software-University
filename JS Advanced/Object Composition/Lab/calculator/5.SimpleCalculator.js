function solve(){
    let selectorOne;
    let selectorTwo;
    let resultSel;
    return {
        init: (selector1, selector2, resultSelector) => {
            selectorOne = document.querySelector(selector1);
            selectorTwo = document.querySelector(selector2);
            resultSel = document.querySelector(resultSelector);
        },
        add: () => {
            resultSel.value  =
            Number(selectorOne.value) +
            Number(selectorTwo.value);
        },
        subtract: () => {
            resultSel.value  =
            Number(selectorOne.value) -
            Number(selectorTwo.value);
        }    
    }
}