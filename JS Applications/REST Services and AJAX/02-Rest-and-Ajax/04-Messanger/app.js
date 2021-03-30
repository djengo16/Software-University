function attachEvents() {
  const url = "https://rest-messanger.firebaseio.com/messanger.json";
  const sendBtn = document.querySelector("#submit");
  const refreshBtn = document.querySelector("#refresh");
  const messageArea = document.querySelector("#messages");

  sendBtn.addEventListener("click", sendData);
  refreshBtn.addEventListener("click", refresh);

  function sendData() {
    const author = document.querySelector("#author");
    const content = document.querySelector("#content");
    let obj = {
      author: author.value,
      content: content.value,
    };

    author.value = "";
    content.value = "";

    fetch(url, {
      method: "POST",
      body: JSON.stringify(obj),
    }).then((r) => refresh());
  }

  function refresh() {
    fetch(url)
      .then((response) => response.json())
      .then((data) => {
        let messages = Object.values(data).reduce((acc, x) => {
          if (isEmty(x.author) && isEmty(x.content)) {
            acc.push(`${x.author}: ${x.content}`);
          }
          return acc;
        }, []);
        messageArea.textContent = messages.join("\n");
        messageArea.scrollTop = messageArea.scrollHeight;
      });
  }

  function isEmty(value) {
    return value !== "" && value !== undefined && value !== null;
  }
}

attachEvents();
