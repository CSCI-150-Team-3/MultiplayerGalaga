<?php //Login.php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackend"; //database name located on mySQL server. 

//Variables submitted by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
 
//Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

//Check connection
if ($conn->connect_error) { //If connection has connection error php will die (equivalent to exit) with message 
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT password FROM users WHERE username = '" . $loginUser . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
 //output data of each row
 while($row = $result->fetch_assoc()) {
    if($row["password"] == $loginPass)
    {
        echo "Login Success.";
        //Add other functionalities here:

        //Get user's data here.

        //Get player info.

        //Get Inventory.
        
        //Modify player data.

        //Update inventory.
    }
    else 
    {
        echo "Wrong Credentials.";
    }
}
} else {
echo "Username does not exist.";
}

//Close connection
$conn->close();


?> 