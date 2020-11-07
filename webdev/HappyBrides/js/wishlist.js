document.addEventListener('DOMContentLoaded', function() {
    // let fakeDatabase = require("./database");
        
    const table = document.getElementById('table');
        
    let draggingEle;
    let draggingRowIndex;
    let placeholder;
    let list;
    let isDraggingStarted = false;
    
    // The current position of mouse relative to the dragging element
    let x = 0;
    let y = 0;
    
    const queryString = window.location.search;

    const urlParams = new URLSearchParams(queryString);
    let json = [];
    //Get the wishlist based on given id
    fakeDatabase.forEach((key) => {
        if(key.id == urlParams.get('id')){
            document.getElementById("WishListTitle").innerHTML = key.title;
            json = key.wishlist;
        }
    });

    // Swap two nodes
    const swap = function(nodeA, nodeB) {
        const parentA = nodeA.parentNode;
        const siblingA = nodeA.nextSibling === nodeB ? nodeA : nodeA.nextSibling;

        // Move `nodeA` to before the `nodeB`
        nodeB.parentNode.insertBefore(nodeA, nodeB);

        // Move `nodeB` to before the sibling of `nodeA`
        parentA.insertBefore(nodeB, siblingA);
    };

    // Check if `nodeA` is above `nodeB`
    const isAbove = function(nodeA, nodeB) {
        // Get the bounding rectangle of nodes
        const rectA = nodeA.getBoundingClientRect();
        const rectB = nodeB.getBoundingClientRect();

        return (rectA.top + rectA.height / 2 < rectB.top + rectB.height / 2);
    };

    const cloneTable = function() {
        list = document.createElement('div');
        table.parentNode.insertBefore(list, table);

        // Hide the original table
        table.style.visibility = 'hidden';

        table.querySelectorAll('tr').forEach(function(row) {
            // Create a new table from given row
            const item = document.createElement('div');
            item.classList.add('draggable');

            const newTable = document.createElement('table');
            newTable.setAttribute('class', 'table table-striped table-dark');

            const newRow = document.createElement('tr');
            const cells = [].slice.call(row.children);
            cells.forEach(function(cell) {
                const newCell = cell.cloneNode(true);
                newCell.style.width = `${parseInt(window.getComputedStyle(cell).width)}px`;
                newRow.appendChild(newCell);
            });

            newTable.appendChild(newRow);
            item.appendChild(newTable);
            list.appendChild(item);
        });
    };

    const mouseDownHandler = function(e) {
        // Get the original row
        const originalRow = e.target.parentNode;
        draggingRowIndex = [].slice.call(table.querySelectorAll('tr')).indexOf(originalRow);

        // Determine the mouse position
        x = e.clientX;
        y = e.clientY;

        // Attach the listeners to `document`
        document.addEventListener('mousemove', mouseMoveHandler);
        document.addEventListener('mouseup', mouseUpHandler);
    };

    const mouseMoveHandler = function(e) {
        if (!isDraggingStarted) {
            isDraggingStarted = true;

            cloneTable();

            draggingEle = [].slice.call(list.children)[draggingRowIndex];
            draggingEle.classList.add('dragging');
            
            // Let the placeholder take the height of dragging element
            // So the next element won't move up
            placeholder = document.createElement('div');
            placeholder.classList.add('placeholder');
            draggingEle.parentNode.insertBefore(placeholder, draggingEle.nextSibling);
            placeholder.style.height = `${draggingEle.offsetHeight}px`;
        }

        // Set position for dragging element
        draggingEle.style.position = 'absolute';
        draggingEle.style.top = `${draggingEle.offsetTop + e.clientY - y}px`;
        draggingEle.style.left = `${draggingEle.offsetLeft + e.clientX - x}px`;

        // Reassign the position of mouse
        x = e.clientX;
        y = e.clientY;

        // The current order
        // prevEle
        // draggingEle
        // placeholder
        // nextEle
        const prevEle = draggingEle.previousElementSibling;
        const nextEle = placeholder.nextElementSibling;
        
        // The dragging element is above the previous element
        // User moves the dragging element to the top
        // We don't allow to drop above the header 
        // (which doesn't have `previousElementSibling`)
        if (prevEle && prevEle.previousElementSibling && isAbove(draggingEle, prevEle)) {
            // The current order    -> The new order
            // prevEle              -> placeholder
            // draggingEle          -> draggingEle
            // placeholder          -> prevEle
            swap(placeholder, draggingEle);
            swap(placeholder, prevEle);
            return;
        }

        // The dragging element is below the next element
        // User moves the dragging element to the bottom
        if (nextEle && isAbove(nextEle, draggingEle)) {
            // The current order    -> The new order
            // draggingEle          -> nextEle
            // placeholder          -> placeholder
            // nextEle              -> draggingEle
            swap(nextEle, placeholder);
            swap(nextEle, draggingEle);
        }
    };

    const updateTableRowNumber = function() {
        let i = 1;
        table.querySelectorAll('tr').forEach(function(row, index) {
            // Ignore the header
            // We don't want user to change the order of header
            if (index === 0) {
                return;
            }
            json[row.cells[0].innerHTML - 1].index = i - 1;
            row.cells[0].innerHTML = i;
            i++;
        });
    }

    const mouseUpHandler = function() {
        // Remove the placeholder
        placeholder && placeholder.parentNode.removeChild(placeholder);
        
        draggingEle.classList.remove('dragging');
        draggingEle.style.removeProperty('top');
        draggingEle.style.removeProperty('left');
        draggingEle.style.removeProperty('position');

        // Get the end index
        const endRowIndex = [].slice.call(list.children).indexOf(draggingEle);

        isDraggingStarted = false;

        // Remove the `list` element
        list.parentNode.removeChild(list);

        // Move the dragged row to `endRowIndex`
        let rows = [].slice.call(table.querySelectorAll('tr'));
        draggingRowIndex > endRowIndex
            ? rows[endRowIndex].parentNode.insertBefore(rows[draggingRowIndex], rows[endRowIndex])
            : rows[endRowIndex].parentNode.insertBefore(rows[draggingRowIndex], rows[endRowIndex].nextSibling);

        // Bring back the table
        table.style.removeProperty('visibility');
        updateTableRowNumber();

        // Remove the handlers of `mousemove` and `mouseup`
        document.removeEventListener('mousemove', mouseMoveHandler);
        document.removeEventListener('mouseup', mouseUpHandler);
    };

    const generateTable = function(jsonData) {
        const tableBody = document.getElementById("table-gifts");
        tableBody.innerHTML = "";
        //Generate a bootstrap 4 table based on our json
        jsonData.forEach((value, index) => {
            const tr = document.createElement('tr');
            const th = document.createElement('th');
            const tdGift = document.createElement('td');
            const tdBuyers = document.createElement('td');
            const tdDelete = document.createElement('td');

            th.setAttribute('scope', 'row');
            th.setAttribute('class', 'draggable');
            th.setAttribute('data-type', 'number');

            const thNumber = document.createTextNode(index + 1);
            const tdGiftValue = document.createTextNode(value.gift);
            const tdBuyersValue = document.createTextNode(value.gifter.join(', '));
            const tdDeleteBtn = document.createElement("BUTTON");

            tdDeleteBtn.setAttribute("id", value.id);

            tdDeleteBtn.onclick = () => {
                jsonData.splice(jsonData.findIndex(element => element.id === value.id), 1);
                generateTable(jsonData);
            }
            const tdDeleteBtnImage = document.createElement("i");

            tdDeleteBtn.setAttribute('class', 'btn btn-danger');
            tdDeleteBtnImage.setAttribute('class', 'fa fa-trash');

            tdDeleteBtn.appendChild(tdDeleteBtnImage);
            
            th.appendChild(thNumber);
            tdGift.appendChild(tdGiftValue);
            tdBuyers.appendChild(tdBuyersValue)
            tdDelete.appendChild(tdDeleteBtn);

            tr.appendChild(th);
            tr.appendChild(tdGift);
            tr.appendChild(tdBuyers);
            tr.appendChild(tdDelete);


            tableBody.appendChild(tr)
        });

        table.querySelectorAll('tr').forEach(function(row, index) {
            // Ignore the header
            // We don't want user to change the order of header
            if (index === 0) {
                return;
            }
            const firstCell = row.firstElementChild;
            firstCell.classList.add('draggable');
            firstCell.addEventListener('mousedown', mouseDownHandler);
        });
    } 
    if(json.length > 0){
        generateTable(json);  
    }
});