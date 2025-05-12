let user=null
const getUser = async () => {
    //const URLParams = new URLSearchParams(window.location.search);
    //const id = URLParams.get("id");
    const id = localStorage.getItem("userId")
    //console.log(id)
    //const response = await fetch(`https://localhost:44345/api/users/${id}`);
    //if (response.ok) {
    //     user = await response.json();

    const userFirstName = localStorage.getItem("userFirstName")
    document.getElementById("titleName").innerHTML = userFirstName;
    const userLastName = localStorage.getItem("userLastName")
    document.getElementById("firstName").value = userFirstName;
    document.getElementById("lastName").value = userLastName;    
    }

getUser();
const showUpdate = () => {
    document.getElementById("updateUser").style.visibility = "visible";
 
}

const updateUser = async () => {
    const id = localStorage.getItem("userId");
    const userName = document.getElementById("userName");
    const password = document.getElementById("password");
    const firstName = document.getElementById("firstName");
    const lastName = document.getElementById("lastName");

    const updateUser = {
        UserId:id,
        Email : userName.value,
        Password: password.value,
        FirstName: firstName.value,
        LastName: lastName.value,
    };
    console.log(updateUser)
    try {
        const response = await fetch(`https://localhost:44345/api/users/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(updateUser)
        });

        if (response.ok) {
            alert('פרטים עודכנו');
        }
        else {
            const badRequestData = await response.text();
            alert(badRequestData);
        }

       
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}