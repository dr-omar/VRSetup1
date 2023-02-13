<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityBackend";

//variables submitted by user:
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
$loginEmail = $_POST["loginEmail"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected sucessfully, now we will show the users. <br/><br/>";
$sql = "SELECT username FROM users WHERE username = '" . $loginUser ."'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    // output name already taken
    echo "Username is already taken";
}
else {
    echo "Username does not exist";
    $sql = "INSERT INTO users (type, username, password, email, level1, level2, level3, level4)
    VALUES (1, "'" . $loginUser . "'", "'" . $loginPass . "'", 
        "'" . $loginEmail . "'", 0, 0, 0, 0)";
    echo $sql;
    if ($conn->query($sql) === TRUE) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}
$conn->close();
?>