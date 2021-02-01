function solve() {
  let [generateBtn, buyBtn] = document.querySelectorAll("button");
  document.querySelector("input").disabled = false;
  generateBtn.addEventListener("click", generate);
  buyBtn.addEventListener("click", buy);
  let tbody = document.querySelector("tbody");

  function generate() {
    let inputData = document.querySelectorAll("textarea")[0];
    let products = JSON.parse(inputData.value);
    [...products].forEach((product) => {
      let tRow = document.createElement("tr");
      let html = ` <td><img src="${product.img}"></td><td><p>${product.name}</p></td>`;
      html += `<td><p>${product.price}</p></td><td><p>${product.decFactor}</p></td>`;
      html += `<td><input type="checkbox" /></td>`;

      tRow.innerHTML = html;
      tbody.appendChild(tRow);
    });
  }

  function buy() {
    let checkedProducts = [...tbody.children].filter(
      (x) => x.lastElementChild.firstElementChild.checked
    );

    let names = `Bought furniture: ${checkedProducts
      .map((x) => x.children[1].textContent.trim())
      .join(", ")}`;
    let totalPrice = `Total price: ${checkedProducts
      .reduce((acc, x) => {
        return acc + Number(x.children[2].textContent);
      }, 0)
      .toFixed(2)}`;
    let avgDecoration = `Average decoration factor: ${(
      checkedProducts.reduce((acc, x) => {
        return acc + Number(x.children[3].textContent);
      }, 0) / checkedProducts.length
    ).toFixed(1)}`;

    document.querySelectorAll(
      "textarea"
    )[1].value = `${names}\n${totalPrice}\n${avgDecoration}`;
  }
}
