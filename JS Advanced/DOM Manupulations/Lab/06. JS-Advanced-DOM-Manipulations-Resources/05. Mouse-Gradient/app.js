function attachGradientEvents() {
  let box = document.getElementById("gradient");
  let result = document.getElementById("result");

  box.addEventListener("mousemove", gradientMove);
  box.addEventListener("mouseout", gradientOut);

  function gradientMove(e) {
    result.textContent = `${Math.floor(
      (e.offsetX / e.target.clientWidth) * 100
    )}%`;
  }

  function gradientOut() {
    result.textContent = "";
  }
}
