namespace DevStation.Controllers {
    export class InboxController {
        public inbox;
        public message;

        public send() {
            this.$http.post(`api/messages/send`, this.message)
                .then((response) => {
                    if (response.status != 400) {
                        alert("The Message was sent successfully");
                    } else {
                        alert("Message could not be sent");
                    }
                })
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }

        constructor(private $http: ng.IHttpService, private $location, private $window) {
            this.$http.get(`/api/messages/currentUser`)
                .then((response) => {
                    this.inbox = response.data;
                })
        }
    }
}