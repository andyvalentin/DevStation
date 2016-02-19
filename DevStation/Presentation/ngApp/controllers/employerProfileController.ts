namespace DevStation.Controllers {
    export class EmployerProfileController {
        public employer;

        public toEmployerEdit() {
            this.$location.path("/employerprofile/edit")
        }

        public editEmployerProfile() {
            this.$http.post(`api/user/employerprofile/edit`, this.employer)
                .then((response) => {
                    this.$location.path("/employerprofile")
                })
        }

        public toAddJob() {
            this.$location.path("/employer/addjob")
        }

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) {
            this.$http.get(`/api/users/employerProfile`)
                .then((response) => {
                    this.employer = response.data;
                })
        }
    }
}