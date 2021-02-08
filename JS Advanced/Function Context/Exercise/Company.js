class Company {
  constructor() {
    this.departments = [];
  }

  addEmployee(username, salary, position, Department) {
    //check if data is valid
    this._validate(username);
    this._validate(position);
    if (Number(salary) < 0) {
      throw new Error("Invalid input!");
    }

    //add employee to department
    let curr = this.departments.find((d) => d.name === Department);

    if (!curr) {
      curr = {
        name: Department,
        employees: [],
      };
      this.departments.push(curr);
    }

    curr.employees.push({ username, salary, position });

    return `New employee is hired. Name: ${username}. Position: ${position}`;
  }
  bestDepartment() {
    let depsWithAvgSalary = this.departments.map((x) => {
      const dep = Object.assign({}, x);

      dep.avgSalary =
        x.employees.reduce((a, e) => {
          a += e.salary;
          return a;
        }, 0) / x.employees.length;
      return dep;
    });

    depsWithAvgSalary.sort((a, b) => b.avgSalary - a.avgSalary);
    let bestDep = depsWithAvgSalary[0];

    if (bestDep) {
      const result = [
        `Best Department is: ${bestDep.name}`,
        `Average salary: ${bestDep.avgSalary.toFixed(2)}`,
      ];
      bestDep.employees
        .sort(
          (a, b) => b.salary - a.salary || a.username.localeCompare(b.username)
        )
        .forEach((e) => {
          result.push(`${e.username} ${e.salary} ${e.position}`);
        });

      return result.join("\n");
    }
  }

  _validate(param) {
    if (param === null || param === undefined || param === "") {
      throw new Error("Invalid input!");
    }
  }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
