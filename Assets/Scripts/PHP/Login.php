    <?php
    include_once('connection.php');

    $loginUser = $_POST["loginUser"];
    $loginPass = $_POST["loginPass"];
    $sql = "SELECT password FROM users WHERE username = '" . $loginUser . "'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            if ($row["password"] == $loginPass) {

                echo "Login Success";
            }else{
                echo "Wrong credentials";
            }
        }
    } else {
        echo "Username does not exist";
    }
    $conn->close();
    ?>