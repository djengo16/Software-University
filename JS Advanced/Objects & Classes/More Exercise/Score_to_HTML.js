function solve(input) {
  input = JSON.parse(input);
  let htmlResult = [];
  htmlResult.push("<table>\n  <tr><th>name</th><th>score</th></tr>");
  for (const current of input) {
    htmlResult.push(
      `  <tr><td>${escapeHTML(current.name)}</td><td>${current.score}</td></tr>`
    );
  }
  htmlResult.push("</table>");
  htmlResult.forEach((x) => console.log(x));

  function escapeHTML(str) {
    "use strict";
    str = str
      .replace(/&/g, "&amp;")
      .replace(/>/g, "&gt;")
      .replace(/</g, "&lt;")
      .replace(/"/g, "&quot;")
      .replace(/'/g, "&#39;");
    return str;
  }
}

solve([
  '[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]',
]);
