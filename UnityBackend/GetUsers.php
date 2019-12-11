<?php // Get Users.php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitybackend"; //database name located on mySQL server. 

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) { //If connection has connection error php will die (equivalent to exit) with message 
    die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully, now we will show the users. <br><br>";

$sql = "SELECT username, level FROM users";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "username: " . $row["username"]. " - level: " . $row["level"]. "<br>";
    }
} else {
    echo "0 results";
}

//Close connection
$conn->close();


?>