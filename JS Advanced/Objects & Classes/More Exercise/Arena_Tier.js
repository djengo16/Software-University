function battle(input) {
  let gladiators = {};
  for (const line of input) {
    if (line == "Ave Cesar") {
      Object.entries(gladiators)
        .sort((a, b) => {
          return b[1].totalSkill - a[1].totalSkill || a[0].localeCompare(b[0]);
        })
        .forEach((x) => {
          console.log(`${x[0]}: ${x[1].totalSkill} skill`);
          Object.entries(x[1].techniques)
            .sort((a, b) => {
              return b[1] - a[1] || a[0].localeCompare(b[0]);
            })
            .forEach((x) => {
              console.log(`- ${x[0]} <!> ${x[1]}`);
            });
        });
    } else if (line.includes("vs")) {
      [gladiatorOne, gladiatorTwo] = line.split(" vs ");
      if (gladiators[gladiatorOne] && gladiators[gladiatorTwo]) {
        let firstTechniques = Object.keys(gladiators[gladiatorOne].techniques);
        let secondTechniques = Object.keys(gladiators[gladiatorTwo].techniques);
        let common = firstTechniques.filter((element) =>
          secondTechniques.includes(element)
        );
        if (common.length === 0) {
          continue;
        } else {
          if (
            gladiators[gladiatorOne].totalSkill >
            gladiators[gladiatorTwo].totalSkill
          ) {
            delete gladiators[gladiatorTwo];
          } else {
            delete gladiators[gladiatorOne];
          }
        }
      }
    } else {
      [gladiator, technique, skill] = line.split(" -> ");
      if (!gladiators[gladiator]) {
        gladiators[gladiator] = {};
        gladiators[gladiator].techniques = {};
        gladiators[gladiator].totalSkill = 0;
      }
      if (!gladiators[gladiator].techniques[technique]) {
        gladiators[gladiator].techniques[technique] = Number(skill);
        gladiators[gladiator].totalSkill += Number(skill);
      } else {
        if (gladiators[gladiator].techniques[technique] < Number(skill)) {
          gladiators[gladiator].totalSkill -=
            gladiators[gladiator].techniques[technique];

          gladiators[gladiator].techniques[technique] = Number(skill);

          gladiators[gladiator].totalSkill +=
            gladiators[gladiator].techniques[technique];
        }
      }
    }
  }
}
battle([
  "Pesho -> Duck -> 400",
  "Julius -> Shield -> 150",
  "Gladius -> Heal -> 200",
  "Gladius -> Support -> 250",
  "Gladius -> Support -> 300",
  "Gladius -> Shield -> 250",
  "Pesho vs Gladius",
  "Gladius vs Julius",
  "Gladius vs Gosho",
  "Ave Cesar",
]);
