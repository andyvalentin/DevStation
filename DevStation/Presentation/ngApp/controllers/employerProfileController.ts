namespace DevStation.Controllers {
    export class EmployerProfileController {
        public user;

        public toEdit() {
            this.$location.path("/user/devprofile/edit")
        }

        public toAddJob() {
            this.$location.path("/user/employer/addjob")
        }

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) {
            this.$http.get(`/api/users/employerProfile`)
                .then((response) => {
                    this.user = response.data;
                })
        }
    }
}