function solve() {
  document.getElementById("send").addEventListener("click", (ev) => {
    let messageContent = document.querySelector("#chat_input");

    let messageElement = document.createElement("div");
    messageElement.setAttribute("class", "message my-message");
    messageElement.textContent = messageContent.value;

    document.getElementById("chat_messages").appendChild(messageElement);

    messageContent.value = "";
  });
}
