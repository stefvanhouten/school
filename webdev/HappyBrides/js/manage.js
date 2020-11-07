document.addEventListener('DOMContentLoaded', function() { 
    let WishListsList = document.getElementById('ActiveWishLists');
    fakeDatabase.forEach((key) => {
        if(key.status == 1){
            let li = document.createElement('li');
            li.setAttribute('class', 'list-group-item d-flex justify-content-between align-items-center');

            let a = document.createElement('a');
            a.setAttribute('href', `../index.html?id=${key.id}`);
            a.innerHTML = key.title;

            let span = document.createElement('span');
            span.setAttribute('class', 'badge badge-primary badge-pill');
            span.innerHTML = key.wishlist.length;

            li.appendChild(a);
            li.appendChild(span);
            WishListsList.appendChild(li);
        }
    });
});