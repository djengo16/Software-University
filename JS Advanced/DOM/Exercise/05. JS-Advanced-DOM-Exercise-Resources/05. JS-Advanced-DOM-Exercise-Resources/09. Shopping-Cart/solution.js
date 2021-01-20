function solve() {
  Array.from(
    document.getElementsByClassName("product-add")
  ).forEach((element) => element.addEventListener("click", addProduct));

  document
    .getElementsByClassName("checkout")[0]
    .addEventListener("click", checkout);
  let boughtProducts = {};

  function addProduct(element) {
    let price = element.currentTarget.nextElementSibling.innerText;

    let name =
      element.currentTarget.previousElementSibling.children[0].innerText;

    if (!boughtProducts.hasOwnProperty(name)) {
      boughtProducts[name] = 0;
    }
    boughtProducts[name] += Number(price);

    document.getElementsByTagName(
      "textarea"
    )[0].value += `Added ${name} for ${price} to the cart.\n`;
  }

  function checkout() {
    Array.from(document.getElementsByTagName("button")).forEach(
      (element) => (element.disabled = true)
    );

    let allProducts = [];
    Object.keys(boughtProducts).forEach((x) => allProducts.push(x));

    let totalPrice = Object.values(boughtProducts).reduce(
      (sum, x) => sum + x,
      0
    );

    document.getElementsByTagName(
      "textarea"
    )[0].value += `You bought ${allProducts.join(
      ", "
    )} for ${totalPrice.toFixed(2)}.`;
  }
}
