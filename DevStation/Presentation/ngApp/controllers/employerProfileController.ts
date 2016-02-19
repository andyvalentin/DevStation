namespace DevStation.Controllers {
    export class EmployerProfileController {
        public user;

        public toEmployerEdit() {
            this.$location.path("/employerprofile/edit")
        }

        public toAddJob() {
            this.$location.path("/employer/addjob")
        }

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) {
            this.$http.get(`/api/users/employerProfile`)
                .then((response) => {
                    this.user = response.data;
                })
        }
    }
}