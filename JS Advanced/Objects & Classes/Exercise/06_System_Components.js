function solve(input){
    let systems = {};

    input.forEach(line => {
        let [system, component, subcomponent] = line.split(' | ');

        if(!systems[system]){
            systems[system] = {};
        }

        if(!systems[system][component]){
            systems[system][component] = [];
        }
        systems[system][component].push(subcomponent);
    });

    Object.entries(systems).sort((a,b) => {
        return Object.entries(b[1]).length - Object.entries(a[1]).length || a[0].localeCompare(b[0]);
    }).forEach(([system,components]) => {
        console.log(system);
        Object.entries(components).sort((a, b) =>{
            return b[1].length - a[1].length;
        }).forEach(([component, subcomponents]) => {
            console.log(`|||${component}`);
            subcomponents.forEach(subc => {
                console.log(`||||||${subc}`)
            })
        })
    });
}

solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);