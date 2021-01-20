function solve() {
  var correctAnswers = [
    "onclick",
    "JSON.stringify()",
    "A programming API for HTML and XML documents",
  ];
  [...document.getElementsByTagName("p")].forEach((element) =>
    element.addEventListener("click", answer)
  );

  let choosedAnswers = [];
  function answer(e) {
    let next = choosedAnswers.length + 1;

    if (correctAnswers.includes(e.target.innerHTML)) {
      choosedAnswers.push(1);
    } else {
      choosedAnswers.push(0);
    }

    if (choosedAnswers.length === 3) {
      let finalOutput = "";
      if (choosedAnswers.some((x) => x === 0)) {
        let totalCorrectAnswers = choosedAnswers.reduce(
          (acc, x) => (acc += x),
          0
        );
        finalOutput = `You have ${totalCorrectAnswers} right answers`;
      } else {
        finalOutput = "You are recognized as top JavaScript fan!";
      }
      let currentSection = document.getElementsByTagName("section")[next - 1];
      currentSection.style.display = "none";

      document.getElementById("results").style.display = "block";
      document.querySelector(".results-inner > h1").innerHTML = finalOutput;
    } else {
      document.getElementsByTagName("section")[next - 1].style.display = "none";

      document.getElementsByTagName("section")[next].style.display = "block";
    }
  }
}
