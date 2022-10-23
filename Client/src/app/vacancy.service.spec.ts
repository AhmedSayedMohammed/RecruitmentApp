import { TestBed } from '@angular/core/testing';

import { VacancyService } from './main.service';

describe('VacancyService', () => {
  let service: VacancyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VacancyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
