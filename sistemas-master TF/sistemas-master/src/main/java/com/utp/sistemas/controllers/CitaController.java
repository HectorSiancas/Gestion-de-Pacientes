package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Cita;
import com.utp.sistemas.services.CitaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/citas")
public class CitaController {

    @Autowired
    private CitaService citaService;

    @PostMapping
    public Cita createCita(@RequestBody Cita cita) {
        return citaService.createCita(cita);
    }

    @GetMapping
    public List<Cita> getAllCitas() {
        return citaService.getAllCitas();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Cita> getCitaById(@PathVariable Integer id) {
        return citaService.getCitaById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Cita> updateCita(@PathVariable Integer id, @RequestBody Cita citaDetails) {
        Cita updatedCita = citaService.updateCita(id, citaDetails);
        return updatedCita != null ? ResponseEntity.ok(updatedCita) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteCita(@PathVariable Integer id) {
        citaService.deleteCita(id);
        return ResponseEntity.noContent().build();
    }
}