<?php //RegisterUser.php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackend"; //database name located on mySQL server. 

//Variables submitted by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
$email = $_POST["email"];
 
//Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

//Check connection
if ($conn->connect_error) { //If connection has connection error php will die (equivalent to exit) with message 
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM users WHERE username = '" . $loginUser . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    //Tell user that name is already taken
    echo "Username is already taken.";
    
} else {
    echo "Creating user...";
    //Insert the user and password into the database
    $sql2 = "INSERT INTO users (username, password, email) VALUES ('" . $loginUser . "', '" . $loginPass . "' , '" . $email . "' )";
    if ($conn->query($sql2) === TRUE) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql2 . "<br>" . $conn->error;
    }
}

//Close connection
$conn->close();

?> 