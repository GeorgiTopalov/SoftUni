function generateReport() {
    let inputElements = Array.from(document.getElementsByTagName('input'));
    let tableRows = document.getElementsByTagName('tr');

    let checkedCols = [];
    let output = [];

    for (let i = 0; i < tableRows.length; i++){
        let currentRow = tableRows[i];
        const currentCol = {};
        
        for (let j = 0; j < currentRow.children.length; j++){
            const cellBlock = currentRow.children[j];
            console.log(cellBlock)
            if ((i === 0) && (cellBlock.children[0].checked)){
                checkedCols.push(j);
                continue;
            }

            if (checkedCols.includes(j)){
                let property = inputElements[j].name;
                currentCol[property] = cellBlock.textContent;
            }
        }

        if (i !== 0){
            output.push(currentCol);
        }
    }

    document.getElementById('output').value = JSON.stringify(output);
}