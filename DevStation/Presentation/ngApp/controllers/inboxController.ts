namespace DevStation.Controllers {
    export class InboxController {
        public inbox;
        public message;
        public userSearch;
        public show;
        public messagesToDelete: number[];

        public populateInbox() {
            this.$http.get(`api/messages/currentUser`)
                .then((response) => {
                    this.inbox = response.data;
                })
        }

        public send() {
            this.$http.post(`api/messages/send`, this.message)
                .then((response) => {
                    if (response.status != 400) {
                        alert("The Message was sent successfully");
                    } else {
                        alert("Message could not be sent");
                    }
                    this.message = null;
                })
        }

        public deleteMany() {
            this.$http.delete(`api/messages/deleteMany`, this.messagesToDelete)
                .then((response) => {
                    this.messagesToDelete.splice(0, this.messagesToDelete.length);
                })
        }

        public deleteOne(id:number) {
            this.$http.delete(`api/messages/deleteOne/${id}`)
                .then((response) => {
                    this.populateInbox();
                })
        }

        public searchUserNames(searchTerm: string) {
            this.userSearch = [];

            if (searchTerm) {
                this.$http.get(`api/messages/user/${searchTerm}`)
                    .then((response) => {
                        this.userSearch = response.data;
                    })
            }
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }

        constructor(private $http: ng.IHttpService, private $location, private $window) {
            this.populateInbox();
        }
    }
}