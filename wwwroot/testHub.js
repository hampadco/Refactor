const connection = new signalR.HubConnectionBuilder()
    .withUrl("/dataHub")
    .build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveData", function (data) {
    console.log(data);
});
