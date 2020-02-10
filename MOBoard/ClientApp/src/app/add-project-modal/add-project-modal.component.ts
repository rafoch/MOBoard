import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalComponent } from '../common/modal/modal.component';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
	selector: 'app-add-project-modal',
	templateUrl: './add-project-modal.component.html',
	styleUrls: [ './add-project-modal.component.scss' ]
})
export class AddProjectModalComponent implements OnInit {
	@ViewChild(ModalComponent, { static: true })
	dialog: ModalComponent;

	newProjectForm: FormGroup;

	constructor(fb: FormBuilder) {
		this.newProjectForm = fb.group({
			name: [ '', Validators.required ]
		});
	}

	ngOnInit() {}

	open() {
		this.dialog.open();
	}

	submitForm() {}
}
