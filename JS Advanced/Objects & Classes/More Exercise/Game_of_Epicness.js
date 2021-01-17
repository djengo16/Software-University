function solve(generals, battles) {
  let kingdoms = {};
  for (const obj of generals) {
    if (!kingdoms[obj.kingdom]) {
      kingdoms[obj.kingdom] = {};
    }
    if (!kingdoms[obj.kingdom][obj.general]) {
      kingdoms[obj.kingdom][obj.general] = { army: 0, wins: 0, losses: 0 };
    }
    kingdoms[obj.kingdom][obj.general].army += obj.army;
  }

  for (const battle of battles) {
    [
      attackingKingdom,
      attackingGeneral,
      defendingKingdom,
      defendingGeneral,
    ] = battle;
    if (attackingKingdom === defendingKingdom) continue;

    let attackerArmy = kingdoms[attackingKingdom][attackingGeneral].army;
    let defenderArmy = kingdoms[defendingKingdom][defendingGeneral].army;
    if (attackerArmy === defenderArmy) {
      continue;
    } else if (attackerArmy > defenderArmy) {
      winBattle(
        attackingKingdom,
        attackingGeneral,
        defendingKingdom,
        defendingGeneral
      );
    } else {
      winBattle(
        defendingKingdom,
        defendingGeneral,
        attackingKingdom,
        attackingGeneral
      );
    }
  }

  let orderedKingDoms = Object.keys(kingdoms).sort(
    (a, b) =>
      getTotal(kingdoms[b], "wins") - getTotal(kingdoms[a], "wins") ||
      getTotal(kingdoms[a], "losses") - getTotal(kingdoms[b], "losses") ||
      a.localeCompare(b)
  );

  let winner = orderedKingDoms[0];
  console.log(`Winner: ${winner}`);
  Object.entries(kingdoms[winner])
    .sort((a, b) => {
      return b[1].army - a[1].army || a[0].localeCompare(b[0]);
    })
    .forEach((x) => {
      console.log(`/\\general: ${x[0]}`);
      console.log(`---army: ${x[1].army}`);
      console.log(`---wins: ${x[1].wins}`);
      console.log(`---losses: ${x[1].losses}`);
    });

  function getTotal(kingdom, keyword) {
    return Object.keys(kingdom).reduce(
      (acc, curr) => acc + kingdom[curr][keyword],
      0
    );
  }
  function winBattle(
    winnerKingdom,
    winnerGeneral,
    losserKingdom,
    losserGeneral
  ) {
    kingdoms[winnerKingdom][winnerGeneral].wins += 1;
    kingdoms[winnerKingdom][winnerGeneral].army += Math.ceil(
      kingdoms[winnerKingdom][winnerGeneral].army * 0.1
    );

    kingdoms[losserKingdom][losserGeneral].losses += 1;
    kingdoms[losserKingdom][losserGeneral].army -= Math.ceil(
      kingdoms[losserKingdom][losserGeneral].army * 0.1
    );
  }
}

solve(
  [
    { kingdom: "Maiden Way", general: "Merek", army: 5000 },
    { kingdom: "Stonegate", general: "Ulric", army: 4900 },
    { kingdom: "Stonegate", general: "Doran", army: 70000 },
    { kingdom: "YorkenShire", general: "Quinn", army: 0 },
    { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
    { kingdom: "Maiden Way", general: "Berinon", army: 100000 },
  ],
  [
    ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Stonegate", "Ulric", "Stonegate", "Doran"],
    ["Stonegate", "Doran", "Maiden Way", "Merek"],
    ["Stonegate", "Ulric", "Maiden Way", "Merek"],
    ["Maiden Way", "Berinon", "Stonegate", "Ulric"],
  ]
);
