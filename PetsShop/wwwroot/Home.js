function showNewUser() {
    document.getElementById("newUser").style.visibility = "visible";
}
const checkPassPower = async () => {
    const password = document.getElementById("password").value;
    try {
        const response = await fetch('https://localhost:44345/api/users/password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(password)
        });
        console.log(response)
        if (response.ok) {
            const level = await response.text();
            alert(level);
        }
        else {
     
               alert('Network response was not ok');

        }

       
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }

}
const register = async () => {
    const userName = document.getElementById("userName");
    const password = document.getElementById("password");
    const firstName = document.getElementById("firstName");
    const lastName = document.getElementById("lastName");

    const newUser = {
        Email : userName.value,
        Password: password.value,
        FirstName: firstName.value,
        LastName: lastName.value,
    };

    try {
        const response = await fetch('https://localhost:44345/api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });

        if (response.ok)
        {
            const user = await response.json();
            alert('משתמש נוסף בהצלחה!');
        }
        else
        {
            const badRequestData = await response.text();
            alert(badRequestData);
        }
            

        
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}
const login = async () => {
        const userName = document.getElementById("userNameLogin");
        const password = document.getElementById("passwordLogin");


    const userLogin = {
            Email : userName.value,
            Password: password.value
        };

        try {
            const response = await fetch('https://localhost:44345/api/users/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },

                body: JSON.stringify(userLogin)
            });

            if (response.ok) {
                const user = await response.json();
                localStorage.setItem("userId", user.userId);
                localStorage.setItem("userFirstName", user.firstName);
                localStorage.setItem("userLastName", user.lastName);
                //window.location.href = `UserDetails.html?id=${user.UserId}`
                window.location.href = 'UserDetails.html'
            }
            else {
                switch (response.status) {
                    case 400:
                        const badRequestData = await response.text();
                        alert(`Bad request: ${badRequestData|| 'Invalid input. Please check your data.'}`);
                        break;
                    case 401:
                        alert("שם משתמש או סיסמא שגויים");
                        break;
                    case 500:
                        alert("שגיאת שרת, נסה שוב מאוחר יותר");
                        break;
                    default:
                        alert(`Unexpected error: ${response.status}`);
                }
            }

         
        } catch (error) {
            console.error('There was a problem with the fetch operation:', error);
        } 
}

