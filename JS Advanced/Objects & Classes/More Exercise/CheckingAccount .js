class CheckingAccount {
  constructor(clientId, email, firstName, lastName) {
    this.clientId = clientId;
    this.email = email;
    this.firstName = firstName;
    this.lastName = lastName;
  }

  set clientId(value) {
    if (value.length != 6) {
      throw new TypeError("Client ID must be a 6-digit number");
    }
    return (this._clientId = value);
  }
  set email(value) {
    let emailPatern = /^[a-zA-Z0-9]+@[a-zA-Z.]+$/g;
    if (!emailPatern.test(value)) {
      throw new TypeError("Invalid e-mail");
    }
    return (this._email = value);
  }
  set firstName(value) {
    if (!(value.length > 3 && value.length < 21)) {
      throw new TypeError(
        "First name must be between 3 and 20 characters long"
      );
    }
    let pattern = /^[A-Za-z]+$/g;
    if (!pattern.test(value)) {
      throw new TypeError("First name must contain only Latin characters");
    }
    return (this._firstName = value);
  }
  set lastName(value) {
    if (!(value.length > 3 && value.length < 21)) {
      throw new TypeError("Last name must be between 3 and 20 characters long");
    }
    let pattern = /^[A-Za-z]+$/g;
    if (!pattern.test(value)) {
      throw new TypeError("Last name must contain only Latin characters");
    }
    return (this._lastName = value);
  }
}

let acc = new CheckingAccount("131455", "ivan@some.com", "Ivan", "Petrov");
console.log("asdasdasd");
