function solve(name,age, weight, height){

    const bmi = Math.round(weight / Math.pow(height/100,2));

    let checkStatus = () => {
        if(bmi < 18.5)
            return 'underweight'
        if(bmi < 25)
            return 'normal'
        if (bmi < 30)
            return 'overweight'
        return 'obese'
    }

    let result = { 
        name: name,
    personalInfo: {
      age: age,
      weight: weight,
      height: height
    },
    BMI: bmi,
    status: checkStatus() };

    if(result.status === 'obese'){
        result.recommendation ='admission required';
    }
    return result;
  
}

console.log(solve('Peter', 29, 75, 182));