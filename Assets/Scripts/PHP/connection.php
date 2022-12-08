<?php
    $servername = "INPUT_SERVER_NAME_HERE";
    $username = "admin";
    $password = "admin";
    $dbname="pubgDb";
    $conn = new mysqli($servername, $username, $password, $dbname);

    if($conn-> connect_error){
        die("Connection to database failed: ". $conn->connect_error);
    }
    echo "Database Connected successfully!";
?>